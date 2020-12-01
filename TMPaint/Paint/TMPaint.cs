using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class frmTMPaint : Form
    {
        Graphics gfx;
        Pen p = new Pen(Color.Black);
        SolidBrush sb = new SolidBrush(Color.Black);
        bool canPaint = false;

        public frmTMPaint()
        {
            InitializeComponent();
            gfx = pnlDraw.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void pnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (canPaint)
            {
                gfx.FillEllipse(sb, e.X - 2, e.Y - 2, 8, 8);
            }
        }

        private void pnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            canPaint = true;
            gfx.FillEllipse(sb, e.X - 2, e.Y - 2, 8, 8);
        }

        private void pnlDraw_MouseUp(object sender, MouseEventArgs e)
        {
            canPaint = false;
        }

        private void frmPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                pnlDraw.Invalidate();
            }

            switch (e.KeyCode)
            {
                case Keys.Z:
                    sb.Color = Color.Red;
                    break;
                case Keys.X:
                    sb.Color = Color.Green;
                    break;
                case Keys.C:
                    sb.Color = Color.Blue;
                    break;
                default:
                    sb.Color = Color.Black;
                    break;
            }
        }
    }
}
