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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Func()
        {
            Random rnd = new Random();
            int count = 0;
            int k = 0;
            int n = (int)numericUpDown1.Value;
            int m = (int)numericUpDown2.Value;
            int[,] arr = new int[n, m];
            int sum = 0;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;
            double MidAr = 0;
            for (int i = 0; i < n; i++)
            {
                MidAr = 0;
                sum = 0;
                for (int j = 0; j < m; j++)
                {
                    k = rnd.Next(-10, 10);
                    arr[i, j] = k;
                    dataGridView1.Rows[i].Cells[j].Value = arr[i, j];
                    sum += arr[i, j];
                    if (j == m - 1)
                    {
                        MidAr = sum / m;
                        if (MidAr < 0) count++;
                    }
                }
            }
            return count;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = Func().ToString();
        }

        public double Task2(out double a, out double b)
        {
            double x = Convert.ToDouble(numericUpDown5.Value);
            double y = Convert.ToDouble(numericUpDown3.Value);
            double z = Convert.ToDouble(numericUpDown4.Value);
        

            a = Math.Round(((Math.Sqrt(Math.Abs(x - 1.0)) - Math.Sqrt(Math.Abs(y))) / (1.0 + (Math.Pow(x, 2) / 2.0) + (Math.Pow(y, 2) / 4.0))), 5, MidpointRounding.AwayFromZero);
            b = Math.Round((x * (Math.Atan(z) + Math.E)),  5, MidpointRounding.AwayFromZero);
            return default;
        }
        private void button1_Click(object sender, EventArgs e)
        {
  
            Task2(out double a, out double  b);
         
            textBox1.Text = "a = " + a.ToString();
            textBox2.Text = "b = " + b.ToString() ;

        }
        double sum()
        {
            int N = (int)numericUpDown6.Value;
            if(N == 0)
            {
                MessageBox.Show("Длина массива не может быть равно 0!", "");
            }
            int[]A= new int[N];
           
            Random rnd  = new Random();
            int Summ = 0;
            dataGridView2.RowCount = 2;
            dataGridView2.ColumnCount = N;
            for (int i = 0; i < A.Length; i++)
            {
                int k = rnd.Next(-10, 10);
             A[i] = k;
             
                dataGridView2.Rows[0].Cells[i].Value = A[i];
                dataGridView2.Columns[i].Width = 25;
                Summ += A[i];
            }

            return Summ;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label14.Text = sum().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
