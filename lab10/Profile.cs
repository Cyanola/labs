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
using static lab10.Program.Employee;
namespace lab10
{
    public partial class Profile : Form
    {

        public Profile()
        {
            InitializeComponent();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            BirthPicker.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DirectoryInfo di = new DirectoryInfo("employees");
            FileInfo[] files = di.GetFiles("*.txt");
            try
            {
                for (int i = 0; i < files.Count(); i++)
                {
                    if (!files[i].Name.Contains("_UserKey"))
                    {
                        var txt = File.ReadLines($@"employees\{files[i].Name}").LastOrDefault();
                 
                        string[] s = File.ReadAllLines($@"employees\{files[i].Name}");

                        if (textBox7.Text == txt)
                        {
                            Program.Employee User = new Program.Employee();
                            User.lastname = s[0];
                            User.name = s[1];
                            User.Patronymic = s[2];
                            User.Post = s[3];
                            User.Faculty = s[4];
                            User.sex = s[5];
                            User.Birthdate = s[6];
                            User.login = s[7];
                            User.password = s[8];
                            User.AutorizationCode = s[9];
                            textBox1.Text = User.lastname.ToString();
                            textBox2.Text = User.name.ToString();
                            textBox3.Text = User.Patronymic.ToString();
                            textBox4.Text = User.Post.ToString();
                            textBox5.Text = User.Faculty.ToString();
                            textBox6.Text = User.sex.ToString();
                            BirthPicker.Visible = true;
                            BirthPicker.Value = DateTime.Parse(User.Birthdate);
                           if( MessageBox.Show($"Объект User создан успешно!\n" +
                                $"Его характеристика:\n" +
                                $"Фамилия: {User.lastname}\n" +
                                $"Имя: {User.name}\n" +
                                $"Отчество: {User.Patronymic}\n" +
                                $"Должность: {User.Post}\n" +
                                $"Факультет: {User.Faculty}\n" +
                                $"Пол: {User.sex}\n" +
                                $"Дата рождения: {User.Birthdate}\n" +
                                $"Логин: {User.login}\n" +
                                $"Пароль: {User.password}\n" +
                                $"Код авторизации: {User.AutorizationCode}", "Успешная авторизация") == DialogResult.OK)
                            {
                                textBox7.Text = "";
                                textBox9.Text = "";
                                textBox10.Text = "";
                            }
                        }

                    }
                }
             
            }
            catch (Exception err)
            {
                MessageBox.Show("Авторизация не пройдена\n" + err.Message, "Ошибка");
            }

        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("employees");

            string pathetic;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ключ авторизации(*.txt)|*UserKey.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            pathetic = openFileDialog.FileName;

            try
            {
                string[] strings = pathetic.Split('_');
                var str = File.ReadAllLines($@"{strings[0] + ".txt"}");
                //        {
                Program.Employee User = new Program.Employee();
                User.lastname = str[0];
                User.name = str[1];
                User.Patronymic = str[2];
                User.Post = str[3];
                User.Faculty = str[4];
                User.sex = str[5];
                User.Birthdate = str[6];
                User.login = str[7];
                User.password = str[8];
                User.AutorizationCode = str[9];

                textBox1.Text = User.lastname.ToString();
                textBox2.Text = User.name.ToString();
                textBox3.Text = User.Patronymic.ToString();
                textBox4.Text = User.Post.ToString();
                textBox5.Text = User.Faculty.ToString();
                textBox6.Text = User.sex.ToString();
                BirthPicker.Visible = true;
                BirthPicker.Value = DateTime.Parse(User.Birthdate);
                if(MessageBox.Show($"Объект User создан успешно!\n" +
                    $"Его характеристика:\n" +
                    $"Фамилия: {User.lastname}\n" +
                    $"Имя: {User.name}\n" +
                    $"Отчество: {User.Patronymic}\n" +
                    $"Должность: {User.Post}\n" +
                    $"Факультет: {User.Faculty}\n" +
                    $"Пол: {User.sex}\n" +
                    $"Дата рождения: {User.Birthdate}\n" +
                    $"Логин: {User.login}\n" +
                    $"Пароль: {User.password}\n" +
                    $"Код авторизации: {User.AutorizationCode}", "Успешная авторизация") == DialogResult.OK)
                
                    {
                        textBox7.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                    }
                

              
            }
            catch (Exception err)
            {
                MessageBox.Show("Авторизация не пройдена\n" + err.Message, "Ошибка");
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var str = textBox9.Text;
            var row = textBox10.Text;
            DirectoryInfo di = new DirectoryInfo("employees");
            FileInfo[] files = di.GetFiles("*.txt");
            try
            {
                for (int i = 0; i < files.Count(); i++)
                {
                    if (!files[i].Name.Contains("_UserKey"))
                    {
                        string[] s = File.ReadAllLines($@"employees\{files[i].Name}");

                        string filetextLogin = s[s.Length - 3];
                        string filetextPas = s[s.Length - 2];

                        if (str == filetextLogin)
                        {
                            if (row == filetextPas)
                            {
                                Program.Employee User = new Program.Employee();
                                User.lastname = s[0];
                                User.name = s[1];
                                User.Patronymic = s[2];
                                User.Post = s[3];
                                User.Faculty = s[4];
                                User.sex = s[5];
                                User.Birthdate = s[6];
                                User.login = s[7];
                                User.password = s[8];
                                User.AutorizationCode = s[9];
                                textBox1.Text = User.lastname.ToString();
                                textBox2.Text = User.name.ToString();
                                textBox3.Text = User.Patronymic.ToString();
                                textBox4.Text = User.Post.ToString();
                                textBox5.Text = User.Faculty.ToString();
                                textBox6.Text = User.sex.ToString();
                                BirthPicker.Visible = true;
                                BirthPicker.Value = DateTime.Parse(User.Birthdate);
                             if(   MessageBox.Show($"Объект User создан успешно!\n" +
                                    $"Его характеристика:\n" +
                                    $"Фамилия: {User.lastname}\n" +
                                    $"Имя: {User.name}\n" +
                                    $"Отчество: {User.Patronymic}\n" +
                                    $"Должность: {User.Post}\n" +
                                    $"Факультет: {User.Faculty}\n" +
                                    $"Пол: {User.sex}\n" +
                                    $"Дата рождения: {User.Birthdate}\n" +
                                    $"Логин: {User.login}\n" +
                                    $"Пароль: {User.password}\n" +
                                    $"Код авторизации: {User.AutorizationCode}", "Успешная авторизация") == DialogResult.OK)
                                {
                                    {
                                        textBox7.Text = "";
                                        textBox9.Text = "";
                                        textBox10.Text = "";
                                    }
                                }

                            }
                            else throw new Exception("Неверный пароль");

                        }
                      
                    }
                   
                }
             
            }
            catch (Exception err)
            {
                MessageBox.Show("Авторизация не пройдена\n" + err.Message, "Ошибка");
            }
        }
    }
}

