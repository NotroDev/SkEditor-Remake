﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkEditor
{
    public class DarkBackColor : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(28, 28, 28);
            }
        }
    }
}

