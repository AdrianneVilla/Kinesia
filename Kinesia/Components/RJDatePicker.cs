using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomControls.RJControls
{
    public class RJDatePicker : DateTimePicker
    {
        //Fields
        //-> Appearance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        //-> Other Values
        private bool droppedDown = false;
        private Image calendarIcon = null;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 40;
        private const int arrowIconWidth = 17;

        //Properties
        public Color SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                UpdateCalendarIcon();
                this.Invalidate();
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        //Constructor
        public RJDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true); // Enable redraw on resize
            this.AutoSize = false;
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);

            // Initialize calendar icon immediately
            UpdateCalendarIcon();
        }

        //Private methods
        private void UpdateCalendarIcon()
        {
            // Load the appropriate icon based on brightness
            if (skinColor.GetBrightness() >= 0.6F)
                calendarIcon = Kinesia.Properties.Resources.calendarDarksmall;
            else
                calendarIcon = Kinesia.Properties.Resources.calendarWhitesmall;
        }

        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidh <= this.Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }

        //Overridden methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
            this.Invalidate(); // Force redraw
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
            this.Invalidate(); // Force redraw
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Update icon button area on resize
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
            this.Invalidate(); // Force redraw on resize
        }

        // ADD THIS NEW METHOD
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // Update icon button area on size change
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
            this.Invalidate(); // Force redraw
            this.Update(); // Immediate redraw
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);

                // Create text area that excludes the icon space
                int iconWidth = GetIconButtonWidth();
                RectangleF textArea = new RectangleF(
                    5, // Left padding
                    0,
                    this.Width - iconWidth - 10, // Subtract icon width and extra padding
                    this.Height
                );

                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;
                textFormat.Alignment = StringAlignment.Near; // Left align text

                // Enable anti-aliasing for smoother rendering
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Draw surface
                graphics.FillRectangle(skinBrush, clientArea);

                //Draw text - use textArea instead of clientArea
                graphics.DrawString(this.Text, this.Font, textBrush, textArea, textFormat);

                //Draw open calendar icon highlight
                if (droppedDown == true)
                    graphics.FillRectangle(openIconBrush, iconArea);

                //Draw border 
                if (borderSize >= 1)
                    graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);

                //Draw icon - ALWAYS draw it, not only on hover
                if (calendarIcon != null)
                {
                    // Center the icon vertically and position it at the right
                    int iconX = this.Width - calendarIcon.Width - 9;
                    int iconY = (this.Height - calendarIcon.Height) / 2;
                    graphics.DrawImage(calendarIcon, iconX, iconY);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Ensure calendar icon is loaded
            if (calendarIcon == null)
                UpdateCalendarIcon();

            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);

            // Force initial paint
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }
    }
}
