using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public class MathCalc
        {
           public double u, v, k;
            private void f1(in double a, in double b, ref double u)
            {
                u = Math.Max(a, b - a);
                this.u = u;
            }
            private void f2(in double a, in double b, ref double v)
            {
                v = Math.Min(a * b, a + b);
                this.v = v;
            }
            private void f3(out double k)
            {
                k = Math.Min(u + v * 2, Math.Round(Math.PI, 2, MidpointRounding.AwayFromZero));
                this.k = k;
            }
            public void f4(in double a, in double b, ref double u, ref double v, out double k)
            {
                f1(a, b, ref u);
                f2(a, b, ref v);
                f3(out k);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathCalc Calc = new MathCalc();

            Calc.f4((double)numericUpDown1.Value, (double)numericUpDown2.Value,
                ref Calc.u,  ref  Calc.v, out Calc.k);

            label2.Text = "u = " + Calc.u.ToString();
            label3.Text = "v = " + Calc.v.ToString();
            label4.Text = "k = " + Calc.k.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

