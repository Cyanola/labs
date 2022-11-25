using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
            Create1.Enabled = true;
            Delete1.Enabled = false;
            Read1.Enabled = false;
            Sum.Enabled = false;
            Write1.Enabled = false;
          write2.Enabled = false;
            delete2.Enabled = false;
            create2.Enabled = true;
            read2.Enabled = false;
        }
        string path = "1.txt";
        Double[] Arr;
        private void button1_Click(object sender, EventArgs e)
        {
            string mes;
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        mes = "Написать программу, которая создает файл, содержащий действительные числа, и " +
                            "находит сумму наибольшего и наименьшего из чисел, содержащихся в файле.";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                    case 1:
                    {
                        mes = "Разработать интерфейс приложения и реализовать функции создания папки.";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                    case 2:
                    {
                        mes = "Разработать интерфейс приложения и реализовать функции создания " +
                            "текстового файла различными методами.";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                case 3:
                    {
                        mes = "Разработать интерфейс приложения и реализовать функции чтения из файла.";
                        MessageBox.Show(mes, "Состояние");
                        break;
                    }
                default:
                            {
                       
                            break;
                        }
                    }
            }

        FileStream file;
        private void Create1_Click(object sender, EventArgs e)
        {
         file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (File.Exists(path)) label6.Text = "Фaйл успешно создан!";
            Write1.Enabled = true;
            Create1.Enabled = false;
        }

        private void Write1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(path))
                {

                    Random rnd = new Random();
                    if (Write1.Enabled == true)
                    {
                        int k = (int)numericUpDown1.Value;
                        dataGridView1.RowCount = 1;
                        dataGridView1.ColumnCount = k;
                        Arr = new Double[k];
                        for (int i = 0; i < Arr.Length; i++)
                        {
                            Arr[i] = Math.Round(rnd.Next(-25, 25) + rnd.NextDouble(), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.Rows[0].Cells[i].Value = Arr[i];
                            dataGridView1.Columns[i].Width = 40;
                            dataGridView1.Rows[0].Height = 20;

                        }
                        label6.Text = "";
                        StreamWriter writer = new StreamWriter(file);
                        for (int i = 0; i < Arr.Length; i++)
                        {
                            writer.WriteLine($"{Arr[i]}");
                        }
                        writer.Close();
                        label6.Text = "Запись осуществлена";
                    }

                    else
                    {
                        throw new Exception("Файла не существует");
                    }
                }
                Write1.Enabled = false;
                Read1.Enabled = true;
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }
            }
        double[] d;
        private void Sum_Click(object sender, EventArgs e)
        {
            double Sum = 0;
               
            Sum = Math.Round(d.Max() + d.Min(), 2, MidpointRounding.AwayFromZero);
            label3.Text = $"Минимальное число {d.Min()}";
            label4.Text = $"Максимальное число {d.Max()}";
            label5.Text = $"Cумма min и max  {Sum}";
            label6.Text = "";
            Delete1.Enabled = true;
        }
   
        private void Read1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(path))
                {

                    d = File.ReadAllLines(path).Select(double.Parse).ToArray();
                    for (int i = 0; i < d.Length; i++)
                    {
                        listView1.Items.Add(d[i].ToString() + "\n");

                    }
                }
                else
                {
                    throw new Exception("Файла не существует");
                }

                label6.Text = "Чтение выполнено";
                Read1.Enabled = false;
                Sum.Enabled = true;
            }
            catch  (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }

        }
            
        
        private void Delete1_Click(object sender, EventArgs e)
        {
            File.Delete(path);
            if (!File.Exists(path)) label6.Text = "Фaйл успешно удален!";
            listView1.Items.Clear();
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            Read1.Enabled = false;
            Sum.Enabled = false;
            Write1.Enabled = false;
            Create1.Enabled = true;
            Delete1.Enabled = false;
            dataGridView1.Rows.Clear();
        }







        string pathDirectory;
        DirectoryInfo fold;
        private void createDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw new Exception("Название папки не может быть пустым");
                else
                {
                    pathDirectory = $"{textBox1.Text}";
                    fold = new DirectoryInfo(pathDirectory);

                    if (!fold.Exists)
                    {
                        fold.Create();


                        label8.Text = ($"Папка по пути {fold.FullName} \n успешно создана!");


                    }
                    else { label8.Text = ($"Папка по пути {fold.FullName} \nуже существует"); }
                 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void deleteDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw new Exception("Название папки не может быть пустым");
                else
                {
                    pathDirectory = $"{textBox1.Text}";
                    fold = new DirectoryInfo(pathDirectory);
                    if (fold.Exists)
                    {
                        fold.Delete();
                        label8.Text = ($"Папка по пути {fold.FullName} \nуспешно удалена!");


                    }
                    else
                    { label8.Text = ($"Папки по пути {fold.FullName} \nне существует"); }

                 
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = " ";
            textBox1.Clear();
        }
   

        private void button3_Click(object sender, EventArgs e)
        {
            string p = $"{textBox2.Text + ".txt"}";
            try
            {
                if (textBox2.Text == "") throw new Exception("Название файла не может быть пустым");
                File.Delete(p);
            

                if (!File.Exists(p))
                {
                    File.Create(p).Close();

                }

                label9.Text = ("Фaйл успешно создан с помощью File!");

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string p = $"{textBox2.Text + ".txt"}";
            FileInfo fi = new FileInfo(p);
            try
            {
                if (textBox2.Text == "") throw new Exception("Название файла не может быть пустым");
                fi.Delete();
         
                if (!fi.Exists)
                {
                    fi.Create().Close();
                }
                label9.Text = ("Фaйл успешно создан c помощью FileInfo!");
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string p = $"{textBox2.Text + ".txt"}";
            try
            {
                if (textBox2.Text == "") throw new Exception("Название файла не может быть пустым");
                File.Delete(p);
                saveFileDialog1.FileName = p;
                saveFileDialog1.DefaultExt = ".txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                 
                    string[] alpha = new string[] { "а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н",
                    "о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я" };
                    String[] ALPHA = new string[] { "А", "Б","В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л",
                "М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я" };
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                    Random rnd = new Random();
                    string[] massiv = new string[10];
                    for (int i = 0; i < massiv.Length; i++)
                    {
                        int m = rnd.Next(0, alpha.Length);
                        int n = rnd.Next(0, ALPHA.Length);
                        massiv[i] = ALPHA[m] + alpha[n] + ALPHA[m] + alpha[n] + " ";
                        streamWriter.WriteLine(massiv[i].ToString() + massiv[i].ToString());

                       
                    }

                    label9.Text = ("Фaйл успешно создан c помощью SaveFileDialog!");
                   
                    streamWriter.Close();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        FileStream fileT4;
  
        private void create2_Click(object sender, EventArgs e)
        {
            try
            {

              pathes = $"{textBox3.Text +".txt"}";
                if (textBox3.Text == "") throw new Exception("Название файла не может быть пустым");
                fileT4 = new FileStream(pathes, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (File.Exists(pathes)) label16.Text = "Фaйл успешно создан!";
                write2.Enabled = true;
                create2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        string pathes;
        private void write2_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (File.Exists(pathes))
                {
                    if (write2.Enabled == true)
                    {

                        string[] alpha = new string[] { "а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н",
                    "о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я" };
                        String[] ALPHA = new string[] { "А", "Б","В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л",
                "М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я" };

                        StreamWriter writer = new StreamWriter(fileT4);

                        Random rnd = new Random();


                        string[] massiv = new string[10];
                        for (int i = 0; i < massiv.Length; i++)
                        {
                            int m = rnd.Next(0, alpha.Length);
                            int n = rnd.Next(0, ALPHA.Length);
                            massiv[i] = ALPHA[m] + alpha[n] + ALPHA[m] + alpha[n] + " ";
                            writer.WriteLine(massiv[i]);

                        }

                        writer.Close();

                    }
                    else
                    {
                        throw new Exception("Файла не существует");
                    }
            }
                write2.Enabled = false;
            read2.Enabled = true;

        }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }

}
            

        private void delete2_Click(object sender, EventArgs e)
        {
            File.Delete(pathes);
            if (!File.Exists(pathes)) label16.Text = "Фaйл успешно удален!";
            listView2.Items.Clear();
            label16.Text = "";
        
           read2.Enabled = false;
          
           write2.Enabled = false;
            create2.Enabled = true;
            delete2.Enabled = false;
         
        }

        private void read2_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            try
                            {
                                string pathes = $"{textBox3.Text + ".txt"}";
                                if (File.Exists(pathes))
                                {
                                    string[] s = File.ReadAllLines(pathes);

                                    listView2.Items.Clear();
                                    for (int i = 0; i < s.Length; i++)
                                    {
                                        listView2.Items.Add(s[i].ToString() + "\n");
                                    }
                                }

                                else
                                {
                                    throw new Exception("Файла не существует");
                                }

                                label16.Text = "Чтение выполнено";
                                //read2.Enabled = false;

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Ошибка");
                            }


                            break;
                        }
                    case 1:
                        {


                            FileStream files = new FileStream(pathes, FileMode.OpenOrCreate);

                            StreamReader reader = new StreamReader(files);
                            listView2.Items.Clear();
                            for (int i = 0; i < files.Length; i++)
                            {
                                listView2.Items.Add(reader.ReadLine() + "\n");
                              
                            }
                            label16.Text = ("\nУспешно прочитано.");
                            //read2.Enabled = false;
                            reader.Close();
                            break;
                        }
                
                    default:
                        {
                            MessageBox.Show("Такого способа нет");
                            break;
                        }
                }
                delete2.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
    
}
