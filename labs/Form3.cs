using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labs
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void chetvert(in int x, in int y, out int res)
        {
            try
            {
                if (x > 0 && y > 0) { res = 1; }
                else if (x > 0 && y < 0) { res = 4; }
                else if (x < 0 && y > 0) { res = 2; }
                else if (x < 0 && y < 0) { res = 3; }
                else throw new Exception("Не допускается значение коррдинаты, равно 0!");

            }
            catch(Exception err) { MessageBox.Show(err.Message, ""); res = default(int); }
   
        }
        private void button1_Click(object sender, EventArgs e)
        {

            chetvert((int)numericUpDown1.Value, (int)numericUpDown2.Value, out int res1);
            chetvert((int)numericUpDown3.Value, (int)numericUpDown4.Value, out int res2);
            if(res1 ==res2)
            {
                label4.Text = $"Точки 1 и 2 лежат в одной четверти номер {res1}";
            }
            else
            {
                label4.Text = $"Точки 1 и 2 не лежат в одной четверти.\n" +
                    $"Точка 1 лежит в четверти {res1},\n" +
                    $"а Точка 2 лежит в четверти {res2}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
