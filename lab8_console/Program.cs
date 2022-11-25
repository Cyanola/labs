using System;
using System.IO;
using System.Linq;
using System.Text;

namespace lab8_console
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
                                Task1();
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();

                                Task2();
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
        static void Task1()
        {
            FileStream file = new FileStream("1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (File.Exists("1.txt")) Console.WriteLine("Фaйл успешно создан!");

            Random rnd = new Random();

            int k = rnd.Next(5, 20);
            Double[] Arr = new Double[k];

            StreamWriter writer = new StreamWriter(file);
            Console.WriteLine("Идет запись в файл");
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = Math.Round(rnd.Next(-10, 10) + rnd.NextDouble(), 2, MidpointRounding.AwayFromZero);
                writer.WriteLine($"{Arr[i]}");

            }

            writer.Close();

            Console.ReadKey();
            Console.WriteLine("Запись успешно осуществлена!");



            double Sum = 0;
        
            Console.WriteLine("Чтение из файла:");
            Console.ReadKey();
            double[] d = File.ReadAllLines("1.txt").Select(double.Parse).ToArray();


            for (int i = 0; i < d.Length; i++)
            {             
                Console.Write(d[i] + " ");
            }
            Sum = Math.Round(d.Min() + d.Max(), 2, MidpointRounding.AwayFromZero);

            Console.WriteLine();

            Console.ReadKey();

            Console.WriteLine($"Сумма минимального {d.Min()} и максимального {d.Max()} чисел равна " + Sum);
            Console.ReadKey();
            File.Delete("1.txt");
            if (!File.Exists("1.txt")) Console.WriteLine("Файл успешно удален!");

        }
        static void Task2()
        {
            string path = @"\folder";
            Console.WriteLine("Работа с папкой");
            DirectoryInfo fold = new DirectoryInfo(path);
            Console.WriteLine("Выберите, что сделать с папкой:");
            Console.WriteLine("1 - Создать\n2 - Удалить");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {

                            if (!fold.Exists)
                            {
                                fold.Create();

                              
                                    Console.WriteLine($"Папка по пути {fold.FullName} успешно создана!");
                                    
                                
                            }
                            else { Console.WriteLine($"Папка по пути {fold.FullName} уже существует"); }
                        
                            break;
                        }
                    case 2:
                        {
                            if (fold.Exists)
                            {
                                fold.Delete();
                               Console.WriteLine($"Папка по пути {fold.FullName} успешно удалена!");
                                    
                                    
                            }
                            else
                            { Console.WriteLine($"Папки по пути {fold.FullName} не существует"); }
                        
                          

                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Такого выбора не существует!");

                            break;
                        }
                }
            }

            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
        }

       static void Task3()
        {
            Console.WriteLine("Методы создания текстовых файлов");
            Console.WriteLine("Выберите способ создания текстового файла:");
            Console.WriteLine("1 - Через использование File\n" +
                "2 - Через использование FileInfo\n");
            
            string path = "Task3.txt";
            try
            {
             
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            File.Delete(path);
                            Console.WriteLine("Существование файла " + File.Exists(path));
                            if (!File.Exists(path))
                            {
                                File.Create(path).Close();
                                    ;
                            }

                            Console.WriteLine("Фaйл успешно создан с помощью File!");

                            Console.WriteLine("Существование файла " + File.Exists(path));
                          
                            break;
                        }
                    case 2:
                        {
                            FileInfo fi = new FileInfo(path);
                            fi.Delete();
                            Console.WriteLine("Существование файла " + File.Exists(path));
                            if (!fi.Exists)
                            {
                                fi.Create().Close();
                            }
                     
                            Console.WriteLine("Фaйл успешно создан c помощью FileInfo!");
                            Console.WriteLine("Существование файла " + File.Exists(path));
                          

                            break;
                   
                        }

            

                    default:
                        {
                       
                            Console.WriteLine("Такого выбора не существует!");
                        
                            break;
                        }
                }
               
            }

            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
        }
        static void Task4()
        { 

            string path = "Task4.txt";
            try
            {
                string[] alpha = new string[] { "а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н",
                    "о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я" };
                String[] ALPHA = new string[] { "А", "Б","В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л",
                "М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я" };
                FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (File.Exists(path)) Console.WriteLine("Фaйл успешно создан!");
                StreamWriter writer = new StreamWriter(file);
                Console.WriteLine("Идет запись в файл");
                Random rnd = new Random();

               
                string[] massiv = new string[10];
                for (int i=0; i<massiv.Length; i++)
                {
                    int m = rnd.Next(0, alpha.Length);
                    int n = rnd.Next(0, ALPHA.Length);
                    massiv[i] = ALPHA[m] + alpha[n] + ALPHA[m] + alpha[n]+ " ";
                    writer.WriteLine(massiv[i]);

                }
            
                writer.Close();

                Console.ReadKey();
                Console.WriteLine("Запись успешно осуществлена!");
                Console.WriteLine("Чтение из файла:");

                Console.WriteLine("Выберите способ чтения текстового файла:");
                Console.WriteLine("1 - С помощью функции File.ReadAllLines(path)\n" +
                  
                    "2 - Через экземпляр класса StreamReader\n");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        {
                            string[] s = File.ReadAllLines(path);

                            Console.WriteLine("Чтение файла с помощью функции File.ReadAllLines(path)");
                            for (int i = 0; i < s.Length; i++)
                            {
                                Console.Write(s[i] + " ");
                            }

                            Console.WriteLine("\nУспешно прочитано.");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            FileStream file1 = new FileStream(path, FileMode.OpenOrCreate);
                        
                            StreamReader reader = new StreamReader(file1);
                            Console.WriteLine("Чтение файла через экземпляр класса StreamReader");
                            for (int i = 0; i < file1.Length; i++)
                            {
                                Console.Write(reader.ReadLine() + " ");
                            }
                            Console.WriteLine("\nУспешно прочитано.");
                      
                           reader.Close();
                            Console.ReadKey();
                            break;

                        }



                    default:
                        {
                           
                            Console.WriteLine("Такого выбора не существует!");
                            
                            break;
                        }
                }
                File.Delete(path);
            }

            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
        }
    }
}





