using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace сортировка2
{
    class ргр
    {
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка вставками

        static int[] InsertionSort(int[] inputarray)
        {
            for (int i = 0; i < inputarray.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (inputarray[j - 1] > inputarray[j])
                    {
                        int temp = inputarray[j - 1];
                        inputarray[j - 1] = inputarray[j];
                        inputarray[j] = temp;

                    }
                    j--;
                }
            }
            return inputarray;
        }

        //сортировка перемешиванием
        static int[] ShakerSort(int[] array)
        {

            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }


        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] num = new int[0];//массив с числами для сортировки вставками
            int[] num2 = new int[0];//массив с числами для шейкерной сортировки
            Console.WriteLine("Размерность массива:   1 - 10^3   2 - 10^5   3 - 10^6");
            int masiv = Convert.ToInt32(Console.ReadLine());

            if (masiv == 1)
            { num = new int[1000]; }
            else if (masiv == 2)
            { num = new int[100000]; }
            else if (masiv == 3)
            { num = new int[1000000]; }
            else
            { Console.WriteLine("Вы ввели что-то не то!"); }

            num2 = new int[num.Length];

            //Console.WriteLine("Введите 1 чтобы выводить массивы данных. Чтобы не выводить - введите другое любое целое число");
            int kolvo = 1;//Convert.ToInt32(Console.ReadLine());

            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();
            Stopwatch stopWatch3 = new Stopwatch();
            Stopwatch stopWatch4 = new Stopwatch();
            Stopwatch stopWatch5 = new Stopwatch();
            Stopwatch stopWatch6 = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Green;
            if (kolvo == 1)
            {
                Console.WriteLine("МАССИВ ВХОДНЫХ ЧИСЕЛ ДО СОРТИРОВОК: ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    num2[i] = num[i] = rand.Next(1000);
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("СОРТИРОВКА ВСТАВКАМИ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            
            stopWatch1.Start();
            InsertionSort(num);
            stopWatch1.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ПЕРВОЙ СОРТИРОВКИ: ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    Console.Write(num[i] + " ");
                }
                Console.WriteLine();
            }

            stopWatch2.Start();
            InsertionSort(num);
            stopWatch2.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ВТОРОЙ СОРТИРОВКИ НЕ ИЗМЕНИЛСЯ (СОРТИРОВКА УПОРЯДОЧЕННОГО МАССИВА) ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ВХОДНЫХ ЧИСЕЛ ДО ТРЕТЬЕЙ СОРТИРОВКИ (ОБРАТНО-УПОРЯДОЧЕННЫЙ МАССИВ): ");
                Console.ForegroundColor = ConsoleColor.White;

                int[] num3 = new int[num.Length];
                int j_1 = num.Length - 1;
                for (int i = 0; i < num.Length; i++)
                {
                    num3[i] = num[j_1];
                    j_1 = j_1 - 1;
                }
                for (int i = 0; i < num.Length; i++)
                {
                    num[i] = num3[i];
                    Console.Write(num[i] + " ");
                }
                Console.WriteLine();
            }

            stopWatch3.Start();
            InsertionSort(num);
            stopWatch3.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ТРЕТЬЕЙ СОРТИРОВКИ: ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    Console.Write(num[i] + " ");
                }
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ШЕЙКЕРНАЯ СОРТИРОВКА ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            stopWatch4.Start();
            ShakerSort(num2);
            stopWatch4.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ПЕРВОЙ СОРТИРОВКИ: ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num2.Length; i++)
                {
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();
            }

            stopWatch5.Restart();
            ShakerSort(num2);
            stopWatch5.Stop();
            
            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ВТОРОЙ СОРТИРОВКИ НЕ ИЗМЕНИЛСЯ (СОРТИРОВКА УПОРЯДОЧЕННОГО МАССИВА) ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ВХОДНЫХ ЧИСЕЛ ДО ТРЕТЬЕЙ СОРТИРОВКИ (ОБРАТНО-УПОРЯДОЧЕННЫЙ МАССИВ): ");
                Console.ForegroundColor = ConsoleColor.White;
                int[] num3 = new int[num2.Length]; 
                int j_1 = num2.Length - 1;
                for (int i = 0; i < num2.Length; i++)
                {
                    num3[i] = num2[j_1];
                    j_1 = j_1 - 1;
                }
                for (int i = 0; i < num2.Length; i++)
                {
                    num2[i] = num3[i];
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();
            }

            stopWatch6.Start();
            ShakerSort(num2);
            stopWatch6.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАССИВ ЧИСЕЛ ПОСЛЕ ТРЕТЬЕЙ СОРТИРОВКИ: ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма сортировки вставками с неупорядоченным массивом: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch1.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма сортировки вставками с упорядоченным массивом: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch2.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма сортировки вставками обратно-упорядоченного массива: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch3.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма шейкерной сортировки с неупорядоченным массивом: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch4.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма шейкерной сортировки с упорядоченным массивом: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch5.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Время выполнения алгоритма шейкерной сортировки обратно-упорядоченного массива: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch6.Elapsed);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

        }
    }
}



