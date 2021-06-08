using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintLine(e.Graphics);
        }

        static int Fact(int x)
        {
            if (x <= 0)
            {
                return 1;
            }
            return x * Fact(x - 1);
        }

        double sin(double x, int step)
        {
            double sum = 0;
            for (int i = 1; i <= step; ++i)
            {
                sum += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Fact(2 * i - 1);
            }
            return sum;
        }

        double cos(double x, int step)
        {
            double sum = 0;
            for (int i = 1; i <= step; ++i)
            {
                sum += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Fact(2 * i - 2);
            }
            return sum;
        }

        double arctan(double x, int step)
        {
            double sum = 0;
            for (int i = 1; i <= step; ++i)
            {
                sum += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return sum;
        }

        void PaintLine(Graphics g)
        {
            double x0 = 10, y0 = 10;
            double x1 = 600, y1 = 350;
            double step = 1;
            int p = 8;
            Pen pen = new Pen(Color.Red, 1);
            g.DrawEllipse(pen, (int)x0 - 3, (int)y0 - 3, 6, 6);
            g.DrawEllipse(pen, (int)x1 - 3, (int)y1 - 3, 6, 6);

            double angle = -arctan((y1 - y0) / (x1 - x0), p);
            double distance = 10;
            while (distance > 0.5)
            {
                y0 -= step * sin(angle, p);
                x0 += step * cos(angle, p);
                g.DrawEllipse(pen, (int)x0, (int)y0, 1, 1);
                distance = Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            }
        }

    }
}