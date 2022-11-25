using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lab10.Program.Employee;
namespace lab10
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }
   void Reg_f()
        {
            Program.Employee emp = new Program.Employee();
            try
            {
                string a = textBox1.Text;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[0] == a.ToLower()[0]) { throw new Exception("Фамилия должна начинаться с прописной буквы!"); }
                    if (a[0] >= 'A' && a[0] <= 'Z')
                {
                    //    if (a[i] >= 'а' && a[i] <= 'я')
                    //    {
                    //        throw new Exception("Использование разных языков в фамилии");
                    //    }
                    //    if (a[i] >= 'A' && a[i] <= 'Z' && i != 0)
                    //    {
                    throw new Exception("Допускаются только символы русского алфавита");
                        //}
                    }
                    if (a[0] >= 'А' && a[0] <= 'Я')
                    {
                        if (a[i] >= 'a' && a[i] <= 'z')
                        {
                        throw new Exception("Допускаются только символы русского алфавита");
                    }
                        if (a[i] >= 'А' && a[i] <= 'Я' && i != 0)
                        {
                            throw new Exception("Использование разных регистров в фамилии");
                        }
                    }
                    if (a[i] >= '0' && a[i] <= '9')
                    {

                        throw new Exception("Введенная последовательность символов не является фамилией");
                    }
                    if (a[i] == '@' || a[i] <= '$' || a[i] == '!' || a[i] == '?' || a[i] == '#'
                        || a[i] == ';' || a[i] == ':' || a[i] == ',' || a[i] == '.' || a[i] == '/'
                        || a[i] == '|' || a[i] == '*' || a[i] == '&' || a[i] == '"' || a[i] == '`' || a[i] == '~' || a[i] == '^'
                        || a[i] == '>' || a[i] == '<')
                    {
                        throw new Exception("Введенная последовательность символов не является фамилией");
                    }

                }
                emp.lastname = a;
                string b = textBox2.Text;
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[0] == b.ToLower()[0])
                    {
                        throw new Exception("Имя должно начинаться с прописной буквы!");
                    }
                        if (b[0] >= 'A' && b[0] <= 'Z')
                    {
                    //if (b[i] >= 'а' && b[i] <= 'я')
                    //{
                    //    throw new Exception("Использование разных языков в имени");
                    //}
                    //if (b[i] >= 'A' && b[i] <= 'Z' && i != 0)
                    //{
                    throw new Exception("Допускаются только символы русского алфавита");
                    //}
                }
                    if (b[0] >= 'А' && b[0] <= 'Я')
                    {
                        if (b[i] >= 'a' && b[i] <= 'z')
                        {
                        throw new Exception("Допускаются только символы русского алфавита");
                    }
                        if (b[i] >= 'А' && b[i] <= 'Я' && i != 0)
                        {
                            throw new Exception("Использование разных регистров в имени");
                        }
                    }
                    if (b[i] >= '0' && b[i] <= '9')
                    {

                        throw new Exception("Введенная последовательность символов не является именем");
                    }
                    if (b[i] == '@' || b[i] <= '$' || b[i] == '!' || b[i] == '?' || b[i] == '#'
                        || b[i] == ';' || b[i] == ':' || b[i] == ',' || b[i] == '.' || b[i] == '/'
                        || b[i] == '|' || b[i] == '*' || b[i] == '&' || b[i] == '"' || b[i] == '`' || b[i] == '~' || b[i] == '^'
                        || b[i] == '>' || b[i] == '<')
                    {
                        throw new Exception("Введенная последовательность символов не является именем");
                    }

                }
                emp.name = b;
                string c = textBox3.Text;
                for (int i = 0; i < b.Length; i++)
                {
                    if (c[0] == c.ToLower()[0])
                    {
                        throw new Exception("Отчество должно начинаться с прописной буквы!");
                    }
                        if (c[0] >= 'A' && c[0] <= 'Z')
                    {
                    //if (c[i] >= 'а' && c[i] <= 'я')
                    //{
                    //    throw new Exception("Использование разных языков в отчестве");
                    //}
                    //if (c[i] >= 'A' && c[i] <= 'Z' && i != 0)
                    //{
                    //    throw new Exception("Использование разных регистров в отчестве");
                    //}
                    throw new Exception("Допускаются только символы русского алфавита");
                }
                    if (c[0] >= 'А' && c[0] <= 'Я')
                    {
                        if (c[i] >= 'a' && c[i] <= 'z')
                        {
                        throw new Exception("Допускаются только символы русского алфавита");
                    }
                        if (c[i] >= 'А' && c[i] <= 'Я' && i != 0)
                        {
                            throw new Exception("Использование разных регистров в отчестве");
                        }
                    }
                    if (c[i] >= '0' && c[i] <= '9')
                    {

                        throw new Exception("Введенная последовательность символов не является отчеством");
                    }
                    if (c[i] == '@' || c[i] <= '$' || c[i] == '!' || c[i] == '?' || c[i] == '#'
                        || c[i] == ';' || c[i] == ':' || c[i] == ',' || c[i] == '.' || c[i] == '/'
                        || c[i] == '|' || c[i] == '*' || c[i] == '&' || c[i] == '"' || c[i] == '`' || c[i] == '~' || c[i] == '^'
                        || c[i] == '>' || c[i] == '<')
                    {
                        throw new Exception("Введенная последовательность символов не является отчеством");
                    }

                }
                emp.Patronymic = c;
                emp.Faculty = Faculty_comboBox.Text;
                emp.sex = Sex_comboBox.Text;
                emp.Post = Post_comboBox.Text;
                emp.Birthdate = BirthPicker.Value.ToShortDateString();
                List<char> ASTR = new List<char>();
                ASTR = textBox4.Text.ToCharArray().ToList();

                if (ASTR.Count >= 4)
                {
                    for (int i = 0; i < ASTR.Count; i++)
                    {

                        if (ASTR.ElementAt(i) >= '0' && ASTR.ElementAt(i) <= '9')
                        {
                            continue;
                        }
                        if (ASTR[i] == '@' || ASTR[i] <= '$' || ASTR[i] == '!' || ASTR[i] == '?' || ASTR[i] == '#'
                            || ASTR[i] == ';' || ASTR[i] == ':' || ASTR[i] == ',' || ASTR[i] == '.' || ASTR[i] == '/'
                            || ASTR[i] == '|' || ASTR[i] == '*' || ASTR[i] == '&' || ASTR[i] == '"' || ASTR[i] == '`' || ASTR[i] == '~' || ASTR[i] == '^'
                            || ASTR[i] == '>' || ASTR[i] == '<')
                        {
                            throw new Exception("В логине не допускаются специальные символы");
                        }
                        if (ASTR.ElementAt(i) >= 'а' && ASTR.ElementAt(i) <= 'я' ||
                              ASTR.ElementAt(i) >= 'А' && ASTR.ElementAt(i) <= 'Я')
                        {
                            throw new Exception("В логине должны содержаться только английские символы");
                        }
                        if (ASTR.ElementAt(i) == ' ')
                        {
                            throw new Exception("В логине не должно быть пробелов");
                        }

                    }
                }
                else
                {
                    throw new Exception("Длина логина должна быть больше 4 символов");
                }
                emp.login = textBox4.Text;


                List<char> list = new List<char>();
                list = textBox5.Text.ToCharArray().ToList();

                if (list.Count >= 8)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list.ElementAt(i) >= '0' && list.ElementAt(i) <= '9')
                        {
                            continue;
                        }
                        if (list.ElementAt(i) == '@' || list.ElementAt(i) <= '$' || list.ElementAt(i) == '!' || list.ElementAt(i) == '?' || list.ElementAt(i) == '#'
                        || list.ElementAt(i) == '.' || list.ElementAt(i) == '&')
                        {
                            continue;
                        }
                        if (list.ElementAt(i) >= 'а' && list.ElementAt(i) <= 'я' ||
                            list.ElementAt(i) >= 'А' && list.ElementAt(i) <= 'Я')
                        {
                            throw new Exception("В пароле должны содержаться только английские символы");
                        }
                        if (list.ElementAt(i) == ' ')
                        {
                            throw new Exception("В пароле не должно быть пробелов");
                        }
                    }
                    bool per = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list.ElementAt(i) >= 'A' && list.ElementAt(i) <= 'Z')
                        {
                            per = true;
                            continue;
                        }
                    }
                    if (per == false) { throw new Exception("Пароль должен содержать заглавные букаы"); }
                    emp.password = textBox5.Text;
                }

                else
                {
                    throw new Exception("Длина пароля должна быть не меньше 8 символов");

                }


                string ssss = emp.lastname + emp.name[0] + emp.Patronymic[0] + ".txt";
                emp.path = $@"employees\{ssss}";
                using (StreamWriter writer = new StreamWriter(emp.path))
                {
                    writer.WriteLine(emp.AutorizationCode);
                    writer.Close();
                }


                string[] s = emp.path.Split('.');
                emp.FileWithAutorizationCode = ($"{s[0]}_UserKey.txt");
                emp.AutorizationCode = GenAutorizationCode();
                //strings.Add(emp.AutorizationCode);
                using (StreamWriter writer = new StreamWriter(emp.FileWithAutorizationCode))
                {
                    writer.WriteLine(emp.AutorizationCode);
                    writer.Close();
                }
                MessageBox.Show($"Ваш код авторизации {emp.AutorizationCode}, сохранен в файле" +
                    $" {emp.FileWithAutorizationCode}");

                using (StreamWriter writer = new StreamWriter(emp.path))
                {
                    writer.WriteLine(emp.lastname);
                    writer.WriteLine(emp.name);
                    writer.WriteLine(emp.Patronymic);
                    writer.WriteLine(emp.sex);
                    writer.WriteLine(emp.Birthdate);
                    writer.WriteLine(emp.Post);

                    writer.WriteLine(emp.Faculty);

                    writer.WriteLine(emp.login);
                    writer.WriteLine(emp.password);
                    writer.WriteLine(emp.AutorizationCode);
                    writer.Close();
                }
                var xs = MessageBox.Show("Файл успешно сохранен"
                                   + Environment.NewLine
                                   + "Просмотреть файл?", "Выполнено",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (xs == DialogResult.Yes)
                {
                    Process.Start(emp.path);
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошмбка");
            }
}

   //public     List<string> strings = new List<string>();
        string GenAutorizationCode()
        {
        
            Random rns = new Random();
            int k = rns.Next(3, 12);
     
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
           
            return new string(Enumerable.Repeat(str, k)
        .Select(s => s[rns.Next(s.Length)]).ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reg_f();
            textBox4.Text = "";
            textBox5.Text = "";
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
