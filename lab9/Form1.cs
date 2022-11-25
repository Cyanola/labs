using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
            Delete1.Enabled = false;
            Read1.Enabled = false;
            Sum.Enabled = false;
            Write1.Enabled = true;
            AddDig.Enabled = false;
            button3.Enabled = false;
        }
        string path = "Fo1.db";
        Double[] Arr;

        private void button1_Click(object sender, EventArgs e)
        {
            string mes;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        mes = "Написать программу, которая создает двоичный файл, содержащий действительные числа, и " +
                            "находит сумму наибольшего и наименьшего из чисел, содержащихся в файле." +
                            " В имеющуюся программу добавить функционал, который в случайно заданную позицию" +
                            " получившегося в первом задании файла, вставляет заданное пользователем число.\"";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
               
                case 1:
                    {
                        mes = "Разработать интерфейс приложения и реализовать" +
                            " функции копирования заданного пользователем файла.";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                case 2:
                    {
                        mes = "Разработать интерфейс приложения и реализовать функции получения информации о заданном файле," +
                            " а именно: время создания файла, время последнего доступа к файлу, время последней записи файла." +
                            " Информацию вывести на экран и сохранить в файле..";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }

       static int k;
        private void Write1_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    if (File.Exists(path))
                    {

                        Random rnd = new Random();
                        if (Write1.Enabled == true)
                        {
                            k = (int)numericUpDown1.Value;
                            dataGridView1.RowCount = 1;
                            dataGridView1.ColumnCount = k;
                            Arr = new Double[k];
                            for (int i = 0; i < Arr.Length; i++)
                            {
                                Arr[i] = Math.Round(rnd.Next(-10, 10) + rnd.NextDouble(), 2, MidpointRounding.AwayFromZero);
                                writer.Write(Arr[i]);
                                dataGridView1.Rows[0].Cells[i].Value = Arr[i];
                                dataGridView1.Columns[i].Width = 40;
                                dataGridView1.Rows[0].Height = 20;

                            }
                            label6.Text = "";
                          
                               
                            }
                       
                            label6.Text = "Запись осуществлена";
                        }

                        else
                        {
                            throw new Exception("Файла не существует");
                        }
                    writer.Close();
                }
                    Write1.Enabled = false;
                AddDig.Enabled = true;
                    Read1.Enabled = true;

                }
            
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }
        }

        List<Double> m;
        private void Read1_Click(object sender, EventArgs e)
        {
            try
            {

                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.ASCII))
                {
                    m = new List<double>();

                    while (reader.PeekChar() > -1)
                    {
                        m.Add(reader.ReadDouble());
                    }
                    foreach (double d in m)
                    {
                        if (listBox1.Items.Contains(d.ToString())) { }
                        else { listBox1.Items.Add(d.ToString() + "\n"); }
                    }

                    reader.Close();
                }
                label6.Text = "Чтение выполнено";
                Read1.Enabled = false;
                Sum.Enabled = true;
            }
            catch      (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }

        }

        private void Sum_Click(object sender, EventArgs e)
        {
            double Sum1 = 0;
            Sum1 = Math.Round(m.Min() + m.Max(), 2, MidpointRounding.AwayFromZero);
            label3.Text = $"Минимальное число {m.Min()}";
            label4.Text = $"Максимальное число {m.Max()}";
            label5.Text = $"Cумма min и max равна {Sum1}";
            label6.Text = "";
            Delete1.Enabled = true;
            Sum.Enabled=false;
        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            File.Delete(path);
            if (!File.Exists(path)) label6.Text = "Фaйл успешно удален!";
            listBox1.Items.Clear();
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            Read1.Enabled = false;
            Sum.Enabled = false;
            AddDig.Enabled = false;
            Write1.Enabled = true;
            Delete1.Enabled = false;
            label8.Text = " ";
            dataGridView1.Rows.Clear();
            m.Clear();
        }

        private void AddDig_Click(object sender, EventArgs e)
        {
            double digit = (double)numericUpDown2.Value;

            using (BinaryWriter writer1 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.Write)))
            {
                Random rd = new Random();
                int s = rd.Next(0, Arr.Length);
             
              

                writer1.Seek(s * sizeof(double), SeekOrigin.Begin);
                writer1.Write(digit);
             label8.Text = ($"Число добавлено на позицию {s} (считая от 0) или {s + 1} (считая от 1)");
                Read1.Enabled = true;
                writer1.Close();
                listBox1.Items.Clear();
               if (m!=null) m.Clear();
            }
        }



        bool overwrite = true;

        string p,p1;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Бинарный файл (*.db)|*.db";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
               p = saveFileDialog.FileName;

                using (BinaryWriter writer = new BinaryWriter(File.Open(p, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {

                    if (textBox1.Text == " ") throw new Exception("Пустая строка!");
                    writer.Write(textBox1.Text);
                    writer.Close();
                }
            
                       }

            catch (Exception err)
            {
               MessageBox.Show((err.Message), "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Бинарный файл (*.db)|*.db";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                p1 = saveFileDialog1.FileName;
            }

            catch (Exception err)
            {
                MessageBox.Show((err.Message), "Ошибка");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try {
                File.Copy(p, p1, overwrite);
                label12.Text = ($"Файл {p} успешнно перезаписан в файл {p1}\n");


                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Бинарный файл (*.db)|*.db";
                if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
                p = openFileDialog.FileName;
                using (BinaryReader reader1 = new BinaryReader(File.Open(p, FileMode.Open)))
                {
                    List<string> str = new List<string>();
                    while (reader1.PeekChar() > -1)
                    {

                        str.Add(reader1.ReadString());
                    }
                    foreach (string s in str)
                    {
                        listBox3.Items.Add($"{s} ");
                    }

                }



                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Бинарный файл (*.db)|*.db";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                p1 = openFileDialog1.FileName;
                using (BinaryReader reader1 = new BinaryReader(File.Open(p1, FileMode.Open)))
                {
                    List<string> str = new List<string>();
                    while (reader1.PeekChar() > -1)
                    {

                        str.Add(reader1.ReadString());
                    }
                    foreach (string s in str)
                    {
                        listBox4.Items.Add($"{s} ");
                    }

                }
                button3.Enabled = true;
            }

            catch (Exception err)
            {
                MessageBox.Show((err.Message), "Ошибка");
            }
        }


        String ps1 = @"filees\1.db";
        String ps2 = @"filees\2.db";
        String ps3 = @"filees\3.db";
        String ps4 = @"filees\4.db";
        String ps5 = @"filees\5.db";
        string ps = " ";
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(ps5) && File.Exists(ps3) && File.Exists(ps4) && File.Exists(ps2) &&
                    File.Exists(ps1) && File.Exists(ps3))
                {
                    button4.Enabled = false;
                    throw new Exception("Файлы уже существуют!");
               
                }

                ps = ps1;

                using (BinaryWriter writer = new BinaryWriter(File.Open(ps, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {


                    writer.Close();
                }


                ps = ps2;

                using (BinaryWriter writer = new BinaryWriter(File.Open(ps, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {


                    writer.Close();
                }


                ps = ps3;

                using (BinaryWriter writer = new BinaryWriter(File.Open(ps, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {

                    writer.Close();
                }


                ps = ps4;

                using (BinaryWriter writer = new BinaryWriter(File.Open(ps, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {


                    writer.Close();
                }


                ps = ps5;

                using (BinaryWriter writer = new BinaryWriter(File.Open(ps, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {

                    writer.Close();
                }
                button4.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show((err.Message), "Ошибка");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Бинарный файл (*.db)|*.db";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            p = openFileDialog.SafeFileName;
            listBox2.Items.Clear();
            listBox5.Items.Clear();
                switch (p)
                {
                    case "1.db":
                        {
                            listBox2.Items.Add($"Дата и время создания файла {ps1}:\t\t{File.GetCreationTime(ps1)}");
                            listBox2.Items.Add($"Время последнего обращения к файлу {ps1}:\t{File.GetLastAccessTime(ps1)}");
                            listBox2.Items.Add($"Время последней записи в файл {ps1}:\t\t{File.GetLastWriteTime(ps1)}");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(ps1, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    listBox5.Items.Add($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(ps1, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {ps1}:\t\t{File.GetCreationTime(ps1)}");
                                writer.Write($"Время последнего обращения к файлу {ps1}:\t{File.GetLastAccessTime(ps1)}");
                                writer.Write($"Время последней записи в файл {ps1}:\t\t{File.GetLastWriteTime(ps1)}");
                                writer.Close();
                            }

                            break;
                        }
                    case "2.db":
                        {
                            listBox2.Items.Add($"Дата и время создания файла {ps2}:\t\t{File.GetCreationTime(ps2)}");
                            listBox2.Items.Add($"Время последнего обращения к файлу {ps2}:\t{File.GetLastAccessTime(ps2)}");
                            listBox2.Items.Add($"Время последней записи в файл {ps2}:\t\t{File.GetLastWriteTime(ps2)}");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(ps2, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    listBox5.Items.Add($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(ps2, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {ps2}:\t\t{File.GetCreationTime(ps2)}");
                                writer.Write($"Время последнего обращения к файлу {ps2}:\t{File.GetLastAccessTime(ps2)}");
                                writer.Write($"Время последней записи в файл {ps2}:\t\t{File.GetLastWriteTime(ps2)}");
                                writer.Close();
                            }
                            break;
                        }
                    case "3.db":
                        {
                            listBox2.Items.Add($"Дата и время создания файла {ps3}:\t\t{File.GetCreationTime(ps3)}");
                            listBox2.Items.Add($"Время последнего обращения к файлу {ps3}:\t{File.GetLastAccessTime(ps3)}");
                            listBox2.Items.Add($"Время последней записи в файл {ps3}:\t\t{File.GetLastWriteTime(ps3)}");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(ps3, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    listBox5.Items.Add($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(ps3, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {ps3}:\t\t{File.GetCreationTime(ps3)}");
                                writer.Write($"Время последнего обращения к файлу {ps3}:\t{File.GetLastAccessTime(ps3)}");
                                writer.Write($"Время последней записи в файл {ps3}:\t\t{File.GetLastWriteTime(ps3)}");
                                writer.Close();
                            }
                            break;
                        }
                    case "4.db":
                        {
                            listBox2.Items.Add($"Дата и время создания файла {ps4}:\t\t{File.GetCreationTime(ps4)}");
                            listBox2.Items.Add($"Время последнего обращения к файлу {ps4}:\t{File.GetLastAccessTime(ps4)}");
                            listBox2.Items.Add($"Время последней записи в файл {ps4}:\t\t{File.GetLastWriteTime(ps4)}");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(ps4, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    listBox5.Items.Add($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(ps4, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {ps4}:\t\t{File.GetCreationTime(ps4)}");
                                writer.Write($"Время последнего обращения к файлу {ps4}:\t{File.GetLastAccessTime(ps4)}");
                                writer.Write($"Время последней записи в файл {ps4}:\t\t{File.GetLastWriteTime(ps4)}");
                                writer.Close();
                            }
                            break;
                        }
                    case "5.db":
                        {
                            listBox2.Items.Add($"Дата и время создания файла {ps5}:\t\t{File.GetCreationTime(ps5)}");
                            listBox2.Items.Add($"Время последнего обращения к файлу {ps5}:\t{File.GetLastAccessTime(ps5)}");
                            listBox2.Items.Add($"Время последней записи в файл {ps5}:\t\t{File.GetLastWriteTime(ps5)}");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(ps5, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    listBox5.Items.Add($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(ps5, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {ps5}:\t\t{File.GetCreationTime(ps5)}");
                                writer.Write($"Время последнего обращения к файлу {ps5}:\t{File.GetLastAccessTime(ps5)}");
                                writer.Write($"Время последней записи в файл {ps5}:\t\t{File.GetLastWriteTime(ps5)}");
                                writer.Close();
                            }
                            break;
                        }
                    default:
                        {
                            label16.Text = "Неверно указано имя файла";
                            break;
                        }
                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                File.Delete(p1);
                File.Delete(p);
                if (!File.Exists(p1) && !File.Exists(p)) { label13.Text = "Файлы успешно удалены"; }
                listBox3.Items.Clear();
                listBox4.Items.Clear();
            }

            catch (Exception err)
            {
                MessageBox.Show((err.Message), "Ошибка");
            }
        }
    }

}
