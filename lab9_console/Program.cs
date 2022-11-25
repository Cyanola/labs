using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using System.Diagnostics;

namespace lab9_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("Выберите номер задания(1-4) и 0, чтобы выйти: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 0: break;
                        case 1:
                            {
                                Console.Clear();
                                Task1_2();
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("Задание предполагает выполнение функционала 1 задания," +
                                    " \nно с добавлением числа на произвольную позицию в файл,\n что было реализовано " +
                                    "как единая функция для 1 задания");
                                Task1_2();
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Task3();

                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Task4();
                                Console.ReadKey();
                                break;
                            }

                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Такого задания не существует!");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
            }
        }
        static void Task1_2()
        {
            string path = "1.db";
            Random rnd = new Random();


            int k;
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    if (File.Exists(path)) Console.WriteLine("Фaйл успешно создан!");
                    Console.WriteLine("Идет запись в файл");
                    Console.WriteLine("Сколько чисел записать?");
            k = Convert.ToInt32(Console.ReadLine());
                    Double[] Arr = new Double[k];
                    for (int i = 0; i < Arr.Length; i++)
                    {

                        Arr[i] = Math.Round(rnd.Next(-10, 10) + rnd.NextDouble(), 2, MidpointRounding.AwayFromZero);
                        writer.Write(Arr[i]);
                    }

                    writer.Close();
                }
  
                Console.WriteLine("Запись успешно осуществлена!");

               
                    Console.WriteLine("Чтение из файла:");
                    Console.ReadKey();
 
                    double Sum = 0;
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.ASCII)) {
                        List<Double> m = new List<double>();
                        while (reader.PeekChar() > -1)
                        {

                            m.Add(reader.ReadDouble());
                        }
                        foreach (double d in m)
                        {
                            Console.Write($"{d} ");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        Sum = Math.Round(m.Min() + m.Max(), 2, MidpointRounding.AwayFromZero);
                        Console.WriteLine($"Сумма минимального {m.Min()} и максимального {m.Max()} чисел равна " + Sum);
                        Console.WriteLine();
                        reader.Close();
                    }

                Console.Write("Желааете добавить число в файл?");
                Console.WriteLine("(Да, Нет, Yes, yes, no, No, y, n, Y, N, YES, NO, ДА, НЕТ, да, нет)");
                try
                {
                    string str = Console.ReadLine();
                    if (str == null) return;
                    if (str == "Yes" || str == "y" || str == "Y" || str == "yes" || str == "YES" || str == "Да" || str == "да" || str == "ДА")
                    {
                
                        using (BinaryWriter writer1 = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.Write)))
                        {
                            Random rd = new Random();
                            int s = rd.Next(0, k-1);
                            Console.WriteLine("Введите число:");
                            double g = Convert.ToDouble(Console.ReadLine());
                     
                            writer1.Seek(s * sizeof(double), SeekOrigin.Begin);
                            writer1.Write(g);
                            Console.WriteLine($"Число добавлено на позицию {s} (считая от 0) или {s+1} (считая от 1)");
                     
                            writer1.Close();
                        }

                        Console.WriteLine("Чтение из файла:");
                        Console.ReadKey();

                        double Sum1 = 0;
                        using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open), Encoding.ASCII))
                        {
                            List<Double> m1 = new List<double>();
                            while (reader1.PeekChar() > -1)
                            {

                                m1.Add(reader1.ReadDouble());
                            }
                            foreach (double d in m1)
                            {
                                Console.Write($"{d} ");
                            }

       
                            Console.WriteLine();
                            Console.ReadKey();
                            Sum1 = Math.Round(m1.Min() + m1.Max(), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Сумма минимального {m1.Min()} и максимального {m1.Max()} чисел равна " + Sum1);
                            Console.WriteLine();
                            reader1.Close();
                        }

                    }
                    else if (str == "No" || str == "n" || str == "N" || str == "no" || str == "NO" || str == "Нет" || str == "нет" || str == "Нет")
                    {
                        return;
                    }
                    else throw new Exception("Такой ответ не корректен");
                    Console.ReadKey();
                  
                }
                catch(Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                File.Delete(path);
                if (!File.Exists(path)) Console.WriteLine("Файл успешно удален!");
            }
           
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Task3()
        {
            string path = "2.db";
           string path1 = "3.db";
          
            bool overwrite = true ;
    
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    if (File.Exists(path)) Console.WriteLine($"Фaйл {path} успешно создан!");
                    writer.Write("абвгдеёж");
                    writer.Close();
                }
                Console.ReadKey();
                using (BinaryWriter writer = new BinaryWriter(File.Open(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    if (File.Exists(path1)) Console.WriteLine($"Фaйл {path1} успешно создан!\n");

                    writer.Close();
                }
                Console.ReadKey();

                Console.WriteLine($"Содержимое файла {path}:");

                using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    List<string> str = new List<string>();
                    while (reader1.PeekChar() > -1)
                    {

                        str.Add(reader1.ReadString());
                    }
                    foreach (string s in str)
                    {
                        Console.Write($"{s} ");
                    }

                }
                Console.WriteLine();
                File.Copy(path, path1, overwrite);
                
                Console.WriteLine($"Файл {path} успешнно перезаписан в файл {path1}\n");

                Console.WriteLine($"Содержимое файла {path1}:");

                using (BinaryReader reader1 = new BinaryReader(File.Open(path1, FileMode.Open)))
                {
                    List<string> str = new List<string>();
                    while (reader1.PeekChar() > -1)
                    {

                        str.Add(reader1.ReadString());
                    }
                    foreach (string s in str)
                    {
                        Console.Write($"{s} ");
                    }

                }
                Console.WriteLine();
                Console.ReadKey();

                File.Delete(path1);
                if (!File.Exists(path1)) Console.WriteLine($"Файл {path1} успешно удален!") ;
                File.Delete(path);
                if (!File.Exists(path)) Console.WriteLine($"Файл {path} успешно удален!");
                Console.WriteLine("Конец");
         
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void Task4()
        {
            String p1 = @"files\1.db";
            String p2 = @"files\2.db";
            String p3 = @"files\3.db";
            String p4 = @"files\4.db";
            String p5 = @"files\5.db";
            string path = " ";
  
         
                            path = p1;
     
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {
                           
                              
                                writer.Close();
                            }
                     
            
                            path = p2;
   
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {
                        
                    
                                writer.Close();
                            }
                 
                  
                            path = p3;
     
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {
                             
                                 writer.Close();
                            }
                  
                
                            path = p4;
          
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {
            
                      
                                writer.Close();
                            }
                      
                
                            path = p5;
          
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {
                        
                      writer.Close();
                            }

       

                Console.WriteLine("Выберите 1 из 5 файлов для получения информации о нем");

                try
                {
                    int k = Convert.ToInt32(Console.ReadLine());
                switch(k)
                {
                    case 1:
                        {
                            path = p1;
                         
                         Console.WriteLine($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                            Console.WriteLine($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                            Console.WriteLine($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                            Console.WriteLine("Содержимое файла:");


                                using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    Console.WriteLine($"{s} ");
                                }

                            }
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                            {

                                writer.Write($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                                writer.Write($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                                writer.Write($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                                writer.Close();
                            }
                     
                            break;
                        }
                    case 2:
                        {
                            path = p2;

                            Console.WriteLine($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                            Console.WriteLine($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                            Console.WriteLine($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                            Console.WriteLine("Содержимое файла:");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    Console.WriteLine($"{s} ");
                                }
                            }
                                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                                {

                                writer.Write($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                                writer.Write($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                                writer.Write($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                                writer.Close();
                                }
                            
                     
                            break;
                        }
                    case 3:
                        {
                            path = p3;
                            Console.WriteLine($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                            Console.WriteLine($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                            Console.WriteLine($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                            Console.WriteLine("Содержимое файла:");

                            using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    Console.WriteLine($"{s} ");
                                }
                            }
                                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                                {


                                writer.Write($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                                writer.Write($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                                writer.Write($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                                writer.Close();
                                }
                            
                       
                            break;
                        }
                    case 4:
                        {
                            path = p4;
                            Console.WriteLine($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                            Console.WriteLine($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                            Console.WriteLine($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                            Console.WriteLine("Содержимое файла:");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    Console.WriteLine($"{s} ");
                                }
                            }
                                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                                {


                                writer.Write($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                                writer.Write($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                                writer.Write($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                                writer.Close();
                                }
                            
                        
                            break;
                        }
                    case 5:
                        {
                            path = p5;
                            Console.WriteLine($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                            Console.WriteLine($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                            Console.WriteLine($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                            Console.WriteLine("Содержимое файла:");


                            using (BinaryReader reader1 = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> str = new List<string>();
                                while (reader1.PeekChar() > -1)
                                {

                                    str.Add(reader1.ReadString());
                                }
                                foreach (string s in str)
                                {
                                    Console.WriteLine($"{s} ");

                                }
                            }
                                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                                {


                                writer.Write($"Дата и время создания файла {path}:\t\t{File.GetCreationTime(path)}");
                                writer.Write($"Время последнего обращения к файлу {path}:\t\t{File.GetLastAccessTime(path)}");
                                writer.Write($"Время последней записи в файл {path}:\t\t{File.GetLastWriteTime(path)}");
                                writer.Close();
                                }
                            
                           
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Файла не существует");
                            break;
                        }
                }
       
            }
                catch (Exception err) { Console.WriteLine(err.Message); }
           
        }
    }
}

