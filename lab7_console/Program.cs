using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab7_console
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
                    string[] s = new string[] { };
                    switch (choice)
                    {
                        case 0: break;
                        case 1:
                            {
                                Console.Clear();
                                int n = -1;
                                while (n != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Выберите номер подзадания(1-3): \n");
                                    Console.WriteLine("Для возврата к выбору заданий введите 0\n");
                                    n = Convert.ToInt32(Console.ReadLine());
                                    switch (n)
                                    {
                                        case 0:
                                            {
                                                Program.Main(s);
                                                break;
                                            }
                                        case 1:
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Количество строк, в которых среднее " +
                                                    $"арифметическое элементов меньше нуля равно {Task1_1()}");
                                                Console.ReadKey();
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Clear();
                                                Task1_2(out double a, out double b);
                                                Console.Write("Значение a равно "); Console.WriteLine(a);
                                                Console.Write("Значение b равно "); Console.WriteLine(b);
                                                Console.ReadKey();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"\nСумма элементов одномерного " +
                                                    $"массива равна {Task1_3()}");
                                                Console.ReadKey();
                                                break;

                                            }
                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Неправильный номер подзадания!");
                                                Console.ReadKey();
                                                break;
                                            }

                                    }
                                }
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
                                Calculation();
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
        public static int Task1_1()
        {
            Random rnd = new Random();
            int count = 0;
            int k = 0;
            Console.WriteLine("Двумерный массив\n");
            Console.WriteLine("Введите количество строк массива\n");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество столбцов массива\n");

                int m = Convert.ToInt32(Console.ReadLine());
                int[,] arr = new int[n, m];
                int sum = 0;

                double MidAr = 0;
                for (int i = 0; i < n; i++)
                {
                    MidAr = 0;
                    sum = 0;
                    for (int j = 0; j < m; j++)
                    {
                        k = rnd.Next(-10, 10);
                        arr[i, j] = k;
                        Console.Write(arr[i, j] + " ");
                        sum += arr[i, j];
                        if (j == m - 1)
                        {
                            MidAr = sum / m;
                            if (MidAr < 0) count++;
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message); Console.ReadKey();
            }
            return count;

        }
        public static double Task1_2(out double a, out double b)
        {
            double x = 0, y = 0, z = 0;
            Console.WriteLine("По формулам варианта посчитать значение а и b:\n\n");
            Console.Write("Введите значение x: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение y: ");
            y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение z: ");
            z = Convert.ToDouble(Console.ReadLine());
            a = (Math.Sqrt(Math.Abs(x - 1)) - Math.Sqrt(Math.Abs(y))) / (1 + (Math.Pow(x, 2) / 2) + (Math.Pow(y, 2) / 4));
            b = x * (Math.Atan(z) + Math.E);
            return default;

        }

        public static double Task1_3()
        {
            int Summ = 0;
            Console.WriteLine("Одномерный массив\n");
            Console.WriteLine("Введите длину массива\n");
            try
            {
                int N = Convert.ToInt32(Console.ReadLine());
                if (N == 0)
                {
                    Console.WriteLine("Длина массива не может быть равно 0!");
                }
                int[] A = new int[N];

                Random rnd = new Random();

                for (int i = 0; i < A.Length; i++)
                {
                    int k = rnd.Next(-10, 10);
                    A[i] = k;


                    Console.Write(A[i] + " ");
                    Summ += A[i];
                }

            }
            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
            return Summ;

        }



        public class MathCalc
        {
            public double u, v, k;
            private void f1(in double a, in double b, ref double u)
            {
                u = Math.Max(a, b - a);
                this.u = u;
            }
            private void f2(in double a, in double b, ref double v)
            {
                v = Math.Min(a * b, a + b);
                this.v = v;
            }
            private void f3(out double k)
            {
                k = Math.Min(u + v * 2, Math.Round(Math.PI, 2, MidpointRounding.AwayFromZero));
                this.k = k;
            }
            public void f4(in double a, in double b, ref double u, ref double v, out double k)
            {
                f1(a, b, ref u);
                f2(a, b, ref v);
                f3(out k);
            }
        }

        public static void Task2()
        {
            MathCalc Calc = new MathCalc();

            Console.WriteLine("Введите значение а\n");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение b\n");

                int b = Convert.ToInt32(Console.ReadLine());
                Calc.f4(a, b,
                ref Calc.u, ref Calc.v, out Calc.k);

            }
            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
            Console.WriteLine($"k = " + Calc.k);
        }
        public static void chetvert(in int x, in int y, out int res)
        {
            try
            {
                if (x > 0 && y > 0) { res = 1; }
                else if (x > 0 && y < 0) { res = 4; }
                else if (x < 0 && y > 0) { res = 2; }
                else if (x < 0 && y < 0) { res = 3; }
                else throw new Exception("Не допускается значение коррдинаты, равно 0!");

            }
            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); res = default(int); }
        }
        public static void Task3()
        {
            Console.WriteLine("Рассчет положения точек в четвертях\n\n");
            Console.WriteLine("Введите X1");
            try
            {
                int X1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите Y1");
                int Y1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите X2");
                int X2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите Y2");
                int Y2 = Convert.ToInt32(Console.ReadLine());
                chetvert(X1, Y1, out int res1);
                chetvert(X2, Y2, out int res2);
                if (res1 == res2)
                {
                    Console.WriteLine($"Точки 1 и 2 лежат в одной четверти номер {res1}");
                }
                else
                {
                    Console.WriteLine($"Точки 1 и 2 не лежат в одной четверти.\n" +
                            $"Точка 1 лежит в четверти {res1},\n" +
                            $"а Точка 2 лежит в четверти {res2}");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message); Console.ReadKey();
            }
        }
        public static void RAST(in double X1, in double Y1, in double X2, in double Y2, out double rast)
        {
            rast = Math.Sqrt(Math.Abs(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2)));
        }
        public static void PERIMETR(out double perimetr, double x1 = 0, double x2 = 2, double x3 = 1, double y1 = 0, double y2 = 0, double y3 = 2)
        {
            RAST(x1, y1, x2, y2, out double rast1);
            RAST(x2, y2, x3, y3, out double rast2);
            RAST(x1, y1, x3, y3, out double rast3);
            perimetr = rast1 + rast2 + rast3;
        }
        public static void S(in double X1, in double Y1, in double X2, in double Y2, in double X3, in double Y3, out double s)
        {
            PERIMETR(out double per, X1, X2, X3, Y1, Y2, Y3);
            double p = per / (double)2.0;

            RAST(X1, Y1, X2, Y2, out double rast1);
            RAST(X2, Y2, X3, Y3, out double rast2);
            RAST(X1, Y1, X3, Y3, out double rast3);

            s = Math.Round(Math.Sqrt(Math.Abs(p * (p - rast1) * (p - rast2) * (p - rast3))),
                6, MidpointRounding.AwayFromZero);
        }
        public static void Calculation()
        {

            try
            {
               string str1 = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";

                Console.WriteLine("Введите X1");
                str1 = Console.ReadLine();
               
                Console.WriteLine("Введите Y1");
                str2 = Console.ReadLine();
                Console.WriteLine("Введите X2");
                str3 = Console.ReadLine();
                Console.WriteLine("Введите Y2");
                str4 = Console.ReadLine();
                Console.WriteLine("Введите X3");
                str5 = Console.ReadLine();
                Console.WriteLine("Введите Y3");
                str6 = Console.ReadLine();

                if (str1 == "" && str2 == "" && str3 == "" && str4 == "" && str5 == "" && str6 == "")
                {
                    PERIMETR(out double per);
                    double p = per / (double)2.0;
                    RAST(0, 0, 2, 0, out double rast1);
                    RAST(2, 0, 1, 2, out double rast2);
                    RAST(0, 0, 1, 2, out double rast3);
                    double sq = Math.Round(Math.Sqrt(Math.Abs(p * (p - rast1) * (p - rast2) * (p - rast3))),
                    6, MidpointRounding.AwayFromZero);
                    Console.WriteLine($"Площадь треугольника равна {sq}");
                }
                else
                {
                    int X1 = Convert.ToInt32(str1);
                    int Y1 = Convert.ToInt32(str2);
                    int X2 = Convert.ToInt32(str3);
                    int Y2 = Convert.ToInt32(str4);
                    int X3 = Convert.ToInt32(str5);
                    int Y3 = Convert.ToInt32(str6);

                    S(Convert.ToDouble(str1), Convert.ToDouble(str2), Convert.ToDouble(str3), 
                        Convert.ToDouble(str4), Convert.ToDouble(str5), Convert.ToDouble(str6), out double square);
                   Console.WriteLine($"Площадь треугольника равна {square}");
                }
            }
            catch (Exception err) { Console.WriteLine(err.Message); Console.ReadKey(); }
        }
    }
}
