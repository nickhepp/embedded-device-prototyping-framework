using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public class ProgressBarWithMarker : UserControl
    {

        private int _maximum = 100;
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                this.Invalidate();
            }
        }

        private int _value = 50;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                this.Invalidate();
            }
        }

        private int? _selectedValue = null;
        public int? SelectedValue
        {
            get => _selectedValue;
            set
            {
                _selectedValue = value;
                this.Invalidate();
            }
        }

        public Color BackgroundColor { get; set; } = SystemColors.ScrollBar;

        public Color ForegroundColor { get; set; } = SystemColors.Highlight;

        public Color SelectedValueColor { get; set; } = Color.LimeGreen;

        public Color BorderColor { get; set; } = SystemColors.ActiveBorder;

        public ProgressBarWithMarker()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // draw the background
            double heightRatio = (double)Value / (double)Maximum;
            int rectHeight = (int)((e.ClipRectangle.Height) * heightRatio);
            Rectangle backgroundRect = new Rectangle(e.ClipRectangle.X,
                e.ClipRectangle.Y, 
                this.Width, rectHeight);

            using (SolidBrush br = new SolidBrush(ForegroundColor))
            {
                e.Graphics.FillRectangle(br, backgroundRect);
            }

            // draw the selected value
            if (SelectedValue.HasValue)
            {
                double lineHeightRatio = (double)SelectedValue / (double)Maximum;
                int lineY = e.ClipRectangle.Y + (int)(e.ClipRectangle.Height * lineHeightRatio);
                using (Pen linePen = new Pen(SelectedValueColor, 3f))
                {
                    Point leftPt = new Point(e.ClipRectangle.X, lineY);
                    Point rightPt = new Point(e.ClipRectangle.Right, lineY);
                    e.Graphics.DrawLine(linePen, leftPt, rightPt);
                }
            }

            // draw the border
            Rectangle borderRect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y,
                e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            using (Pen pn = new Pen(BorderColor, 1.0f))
            {
                e.Graphics.DrawRectangle(pn, borderRect);
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProgressBarWithMarker
            // 
            this.ResumeLayout(false);

        }
    }
}
