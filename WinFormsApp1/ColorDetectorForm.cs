using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class ColorDetectorForm : Form
    {
        public event EventHandler<ColorEventArgs> ColorUpdated;

        private System.Windows.Forms.Timer timer;

        public ColorDetectorForm()
        {
            Initialize();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Set the interval to 100 milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Initialize()
        {
            this.StartPosition = FormStartPosition.Manual;
             this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - 150) / 2, (Screen.PrimaryScreen.Bounds.Height - 50) / 2);
            this.Size = new Size(150, 50);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true; // Set to true to keep the form on top of other windows
            this.ShowInTaskbar = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Color dominantColor = GetDominantColor();

             OnColorUpdated(new ColorEventArgs(dominantColor));
        }

        protected virtual void OnColorUpdated(ColorEventArgs e)
        {
            ColorUpdated?.Invoke(this, e);
        }

        private Color GetDominantColor()
        {
            Rectangle bounds = new Rectangle(436, 78, 1101 - 436, 623 - 78); // Updated scanning area bounds
            using (Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
                }

                return GetDominantColorFromBitmap(screenshot);
            }
        }

        private Color GetDominantColorFromBitmap(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * bitmap.Height;
            byte[] pixelData = new byte[byteCount];
            IntPtr scan0 = bitmapData.Scan0;

            System.Runtime.InteropServices.Marshal.Copy(scan0, pixelData, 0, byteCount);
            bitmap.UnlockBits(bitmapData);

            int[] totals = new int[] { 0, 0, 0 };
            int width = bitmap.Width * bytesPerPixel;

            for (int y = 0; y < bitmap.Height; y++)
            {
                int yOffset = y * bitmapData.Stride;
                for (int x = 0; x < width; x += bytesPerPixel)
                {
                    int blue = pixelData[yOffset + x];
                    int green = pixelData[yOffset + x + 1];
                    int red = pixelData[yOffset + x + 2];

                    totals[0] += red;
                    totals[1] += green;
                    totals[2] += blue;
                }
            }

            int count = bitmap.Width * bitmap.Height;
            int averageRed = totals[0] / count;
            int averageGreen = totals[1] / count;
            int averageBlue = totals[2] / count;

            return Color.FromArgb(averageRed, averageGreen, averageBlue);
        }
    }

    public class ColorEventArgs : EventArgs
    {
        public Color Color { get; }

        public ColorEventArgs(Color color)
        {
            Color = color;
        }
    }
}
