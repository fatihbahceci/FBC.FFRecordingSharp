namespace FBC.FFRecordingSharp.Helpers
{
    public class RegionSelectForm : Form
    {
        public Rectangle SelectedRegion { get; private set; }
        private Point _startPoint;

        public RegionSelectForm()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            Opacity = 0.5; // Yarı şeffaf
            BackColor = Color.Black;
            DoubleBuffered = true;

            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
            MouseUp += OnMouseUp;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var endPoint = e.Location;
                SelectedRegion = new Rectangle(
                    Math.Min(_startPoint.X, endPoint.X),
                    Math.Min(_startPoint.Y, endPoint.Y),
                    Math.Abs(_startPoint.X - endPoint.X),
                    Math.Abs(_startPoint.Y - endPoint.Y)
                );

                Invalidate(); // Ekranı yeniden çiz
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new SolidBrush(Color.FromArgb(128, Color.White)))
            {
                e.Graphics.FillRectangle(brush, SelectedRegion);
            }
        }
    }

}
