using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIS329_NyanCatAdv
{
    public class OvalPictureBox : PictureBox
    {
        public int baseSpeed { get; set; }
        public int gravityConstant { get; set; }

        public string name { get; set; }

        public OvalPictureBox()
        {
            this.BackColor = Color.DarkGray;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width, this.Height));
                this.Region = new Region(gp);
            }
        }
    }
}
