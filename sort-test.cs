﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace сортування
{
    class ргр
    {
        // метод обміну елементів
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        // сортування вставками
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

        // шейкерне сортування
        static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                // прохід зліва направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                // прохід справа наліво
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                // якщо не було жодного обміну — вихід
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
            int[] num = new int[0];  // масив чисел для сортування вставками
            int[] num2 = new int[0]; // масив чисел для шейкерного сортування
            Console.WriteLine("Розмірність масиву:   1 - 10^3   2 - 10^5   3 - 10^6");
            int masiv = Convert.ToInt32(Console.ReadLine());

            if (masiv == 1)
            { num = new int[1000]; }
            else if (masiv == 2)
            { num = new int[100000]; }
            else if (masiv == 3)
            { num = new int[1000000]; }
            else
            { Console.WriteLine("Ви ввели щось некоректне!"); }

            num2 = new int[num.Length];

            int kolvo = 1;

            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();
            Stopwatch stopWatch3 = new Stopwatch();
            Stopwatch stopWatch4 = new Stopwatch();
            Stopwatch stopWatch5 = new Stopwatch();
            Stopwatch stopWatch6 = new Stopwatch();

            Console.ForegroundColor = ConsoleColor.Green;
            if (kolvo == 1)
            {
                Console.WriteLine("МАСИВ ВХІДНИХ ЧИСЕЛ ДО СОРТУВАННЯ:");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    num2[i] = num[i] = rand.Next(1000);
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("СОРТУВАННЯ ВСТАВКАМИ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            stopWatch1.Start();
            InsertionSort(num);
            stopWatch1.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАСИВ ПІСЛЯ ПЕРШОГО СОРТУВАННЯ:");
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
                Console.WriteLine("МАСИВ ПІСЛЯ ДРУГОГО СОРТУВАННЯ (ВЖЕ ВІДСОРТОВАНИЙ):");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАСИВ ДО ТРЕТЬОГО СОРТУВАННЯ (ЗВОРОТНІЙ ПОРЯДОК):");
                Console.ForegroundColor = ConsoleColor.White;

                int[] num3 = new int[num.Length];
                int j_1 = num.Length - 1;
                for (int i = 0; i < num.Length; i++)
                {
                    num3[i] = num[j_1];
                    j_1--;
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
                Console.WriteLine("МАСИВ ПІСЛЯ ТРЕТЬОГО СОРТУВАННЯ:");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    Console.Write(num[i] + " ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ШЕЙКЕРНЕ СОРТУВАННЯ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            stopWatch4.Start();
            ShakerSort(num2);
            stopWatch4.Stop();

            if (kolvo == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАСИВ ПІСЛЯ ПЕРШОГО ШЕЙКЕРНОГО СОРТУВАННЯ:");
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
                Console.WriteLine("МАСИВ ПІСЛЯ ДРУГОГО СОРТУВАННЯ (ВЖЕ ВІДСОРТОВАНИЙ):");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("МАСИВ ДО ТРЕТЬОГО СОРТУВАННЯ (ЗВОРОТНІЙ ПОРЯДОК):");
                Console.ForegroundColor = ConsoleColor.White;
                int[] num3 = new int[num2.Length];
                int j_1 = num2.Length - 1;
                for (int i = 0; i < num2.Length; i++)
                {
                    num3[i] = num2[j_1];
                    j_1--;
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
                Console.WriteLine("МАСИВ ПІСЛЯ ТРЕТЬОГО ШЕЙКЕРНОГО СОРТУВАННЯ:");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < num.Length; i++)
                {
                    Console.Write(num2[i] + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Час сортування вставками (невідсортований масив): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch1.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Час сортування вставками (відсортований масив): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch2.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Час сортування вставками (зворотний порядок): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch3.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Час шейкерного сортування (невідсортований масив): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch4.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Час шейкерного сортування (відсортований масив): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch5.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Час шейкерного сортування (зворотний порядок): {0:hh\\:mm\\:ss\\.fffffff}", stopWatch6.Elapsed);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
    }
}

