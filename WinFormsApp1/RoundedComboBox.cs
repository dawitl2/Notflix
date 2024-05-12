using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class RoundedComboBox : ComboBox
    {
        // Radius for rounded corners
        public int CornerRadius { get; set; } = 11;

        // Default back color
        public Color DefaultBackColor { get; set; } = SystemColors.Control;

        // Default fore color
        public Color DefaultForeColor { get; set; } = SystemColors.ControlText;

        // Color for the edge
        public Color EdgeColor { get; set; } = Color.Black;

        public RoundedComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (e.Index < 0)
                return;

            e.DrawBackground();

            // Draw the text
            string text = Items[e.Index].ToString();
            using (SolidBrush brush = new SolidBrush(DefaultForeColor))
            {
                e.Graphics.DrawString(text, Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a graphics path to define the rounded rectangle
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1); // Adjusted bounds
            int radius = CornerRadius * 2;

            // Add arcs to the path for the corners
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Draw the rounded rectangle
            using (Pen borderPen = new Pen(EdgeColor, 3))
            {
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            Invalidate();
        }
    }
}
