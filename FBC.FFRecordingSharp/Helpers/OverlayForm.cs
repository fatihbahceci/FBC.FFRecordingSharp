using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBC.FFRecordingSharp.Helpers
{
    public partial class OverlayForm : Form
    {
        private Rectangle captureArea;
        private Color frameColor = Color.Red;
        public OverlayForm(Rectangle captureArea, Color frameColor)
        {
            this.captureArea = captureArea;
            //InitializeComponent();
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Location = new Point(0, 0);
            this.Bounds = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.ShowInTaskbar = false;
            this.frameColor = frameColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            const int penWidth = 2;

            base.OnPaint(e);
            using (Pen pen = new Pen(this.frameColor, penWidth))
            {
                var outsideOfCaptureArea = new Rectangle(
                    captureArea.X - penWidth,
                    captureArea.Y - penWidth,
                    captureArea.Width + penWidth * 2,
                    captureArea.Height + penWidth * 2);
                //e.Graphics.DrawRectangle(pen, 0, 0, this.Bounds.Width, this.Bounds.Height);
                e.Graphics.DrawRectangle(pen, outsideOfCaptureArea);
            }
        }
    }
}
