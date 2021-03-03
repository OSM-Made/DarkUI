using DarkUI.Config;
using DarkUI.Renderers;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkToolStrip : ToolStrip
    {
        #region Constructor Region

        public DarkToolStrip()
        {
            Renderer = new DarkToolStripRenderer();
            Padding = new Padding(5, 0, 1, 0);
            AutoSize = false;
            Size = new Size(1, 28);
        }

        #endregion

        #region Paint Region

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var b = new SolidBrush(Colors.GreyBackground))
            {
                g.FillRectangle(b, ClientRectangle);
            }

            using (var p = new Pen(Colors.DarkBorder))
            {
                g.DrawLine(p, ClientRectangle.Left, (ClientSize.Height - 2), ClientRectangle.Right, (ClientSize.Height - 2));
            }

            using (var p = new Pen(Colors.LightBorder))
            {
                g.DrawLine(p, ClientRectangle.Left, (ClientSize.Height - 2) + 1, ClientRectangle.Right, (ClientSize.Height - 2) + 1);
            }
        }

        #endregion
    }
}
