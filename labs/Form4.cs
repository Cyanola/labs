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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }
        public void RAST(in double X1, in double Y1, in double X2, in double Y2, out double rast)
        {
            rast = Math.Sqrt(Math.Abs(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2)));
        }
        public void PERIMETR(out double perimetr, double x1 = 0, double x2 = 2, double x3 = 1, double y1 = 0, double y2 = 0, double y3 = 2)
        {
            RAST(x1, y1, x2, y2, out double rast1);
            RAST(x2, y2, x3, y3, out double rast2);
            RAST(x1, y1, x3, y3, out double rast3);
            perimetr = rast1 + rast2 + rast3;
        }
        public void S(in double X1, in double Y1, in double X2, in double Y2, in double X3, in double Y3, out double s)
        {
            PERIMETR(out double per, X1, X2, X3, Y1, Y2, Y3);
            double p = per / (double)2.0;

            RAST(X1, Y1, X2, Y2, out double rast1);
            RAST(X2, Y2, X3, Y3, out double rast2);
            RAST(X1, Y1, X3, Y3, out double rast3);

            s = Math.Round(Math.Sqrt(Math.Abs(p * (p - rast1) * (p - rast2) * (p - rast3))),
                6, MidpointRounding.AwayFromZero);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String str1 = textBox1.Text;
            String str2 = textBox2.Text;
            String str3 = textBox3.Text;
            String str4 = textBox4.Text;
            String str5 = textBox5.Text;
            String str6 = textBox6.Text;

            String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String alphabet = "abcdefghijklmnopqrstuvwxyz";
            String alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            String ALPHA = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            try
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str1[i] == ALPHABET[i] || str1[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str1[i] == ALPHA[i] || str1[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }
                for (int i = 0; i < str2.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str2[i] == ALPHABET[i] || str2[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str2[i] == ALPHA[i] || str2[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }
                for (int i = 0; i < str3.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str3[i] == ALPHABET[i] || str3[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str3[i] == ALPHA[i] || str3[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }
                for (int i = 0; i < str4.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str4[i] == ALPHABET[i] || str4[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str4[i] == ALPHA[i] || str4[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }
                for (int i = 0; i < str5.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str5[i] == ALPHABET[i] || str5[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str5[i] == ALPHA[i] || str5[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }
                for (int i = 0; i < str6.Length; i++)
                {
                    for (int j = 0; j < ALPHABET.Length; j++)
                    {
                        if (str6[i] == ALPHABET[i] || str6[i] == alphabet[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                    for (int j = 0; j < ALPHA.Length; j++)
                    {
                        if (str6[i] == ALPHA[i] || str6[i] == alpha[j])
                        {
                            throw new Exception("Введенная последовательность символов не является числом");
                        }
                    }
                }

                if (str1 == "" && str2 == "" && str3 == "" && str4 == "" && str5 == "" && str6 == "")
                {
                    PERIMETR(out double per);
                    double p = per / (double)2.0;
                    RAST(0, 0, 2,0, out double rast1);
                    RAST(2, 0, 1,2, out double rast2);
                    RAST(0, 0, 1,2, out double rast3);
                    double sq = Math.Round(Math.Sqrt(Math.Abs(p * (p - rast1) * (p - rast2) * (p - rast3))),
                    6, MidpointRounding.AwayFromZero);
                    label7.Text = $"Площадь треугольника равна {sq}";
                }
                else
                {
                    S(Convert.ToDouble(str1), Convert.ToDouble(str2), Convert.ToDouble(str3), Convert.ToDouble(str4), Convert.ToDouble(str5), Convert.ToDouble(str6), out double square);
                    label7.Text = $"Площадь треугольника равна {square}";
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message, "Ошибка"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            this.label7.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
