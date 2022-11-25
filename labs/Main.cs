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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 70, 70);
            Region rgn = new Region(path);
            button5.Region = rgn;
            button3.Region = rgn;
            button4.Region = rgn;
            button1.Region = rgn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }
    }
}
