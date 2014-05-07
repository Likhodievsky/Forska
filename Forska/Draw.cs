using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Forska
{
    class Draw
    {
        Graphics g;
        public Draw(Graphics g)
        {
            this.g = g;
        }

        public void draw_tree(int x, int y, double d1, double d2)
        {
            g.FillEllipse((Brushes.Chartreuse), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2, y - Convert.ToInt32(d2) / 2), new Size(Convert.ToInt32(d2), Convert.ToInt32(d2))));
            g.DrawEllipse(new Pen(Brushes.Green, 1), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2, y - Convert.ToInt32(d2) / 2), new Size(Convert.ToInt32(d2), Convert.ToInt32(d2))));
            g.FillEllipse((Brushes.Brown), new Rectangle(new Point(x - Convert.ToInt32(d2) / 2 + Convert.ToInt32(d2) / 2 - Convert.ToInt32(d1) / 2, y - Convert.ToInt32(d2) / 2 + Convert.ToInt32(d2) / 2 - Convert.ToInt32(d1) / 2), new Size(Convert.ToInt32(d1), Convert.ToInt32(d1))));
        }
    }
}
