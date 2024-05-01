using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class RoundedButton : Button
    {
        // Radius for rounded corners
        public int CornerRadius { get; set; } = 30;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a graphics path to define the rounded rectangle
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height); // Adjusted bounds
            int radius = CornerRadius * 2;

            // Add arcs to the path for the corners
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Draw the rounded rectangle
            this.Region = new Region(path);
        }
    }
}
