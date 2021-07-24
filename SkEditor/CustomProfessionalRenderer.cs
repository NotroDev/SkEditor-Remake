using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using FastColoredTextBoxNS;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace SkEditor
{
    class CustomProfessionalRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(Color.FromArgb(150, 74, 118, 240)))
                {
                    e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
                }
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle r = Rectangle.Inflate(e.Item.ContentRectangle, -2, -2);

            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }
            else
            {
                using (Pen p = new Pen(ProfessionalColors.SeparatorLight))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
    }
}
