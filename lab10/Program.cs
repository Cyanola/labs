using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

       public class Employee
        {
           public string name { get; set; }
           public string Patronymic { get; set; }
        public    string lastname { get; set; }

            public string Birthdate { get; set; }
            public string Post { get; set; }
            public string sex { get; set; }
            public string Faculty { get; set; }

            public string login { get; set; }
            public string password { get; set; }
            public String AutorizationCode { get; set; }
            public String FileWithAutorizationCode { get; set; }
            public String path { get; set; }
        }
    }
}
