using System;
using System.Diagnostics;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Console benchmarking tool comparing Insertion Sort and Shaker Sort
    /// on integer arrays of different sizes and orderings.
    /// </summary>
    class SortingBenchmark
    {
        /// <summary>
        /// Swaps two integers by reference.
        /// </summary>
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Insertion Sort — O(n²) average, O(n) best case.
        /// Each element is shifted into its correct position in the sorted prefix.
        /// </summary>
        static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                    j--;
                }
            }
            return array;
        }

        /// <summary>
        /// Shaker Sort (bidirectional bubble sort) — O(n²) average, O(n) best case.
        /// Alternates left-to-right and right-to-left passes with an early-exit flag.
        /// </summary>
        static int[] ShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool swapped = false;

                // Left to right pass
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }

                // Right to left pass
                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapped = true;
                    }
                }

                // Early exit if no swaps occurred
                if (!swapped) break;
            }
            return array;
        }

        /// <summary>
        /// Reverses an array in place.
        /// </summary>
        static void Reverse(int[] array)
        {
            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                Swap(ref array[left], ref array[right]);
                left++;
                right--;
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("Select array size:");
            Console.WriteLine("  1 — 1,000 elements");
            Console.WriteLine("  2 — 100,000 elements");
            Console.WriteLine("  3 — 1,000,000 elements");
            Console.Write("Your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            int size = choice switch
            {
                1 => 1_000,
                2 => 100_000,
                3 => 1_000_000,
                _ => throw new ArgumentException("Invalid choice")
            };

            // Fill arrays with random values
            int[] insertionArray = new int[size];
            int[] shakerArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                insertionArray[i] = shakerArray[i] = rand.Next(1000);
            }

            // Print input if small enough
            if (size == 1_000)
            {
                Console.WriteLine("\nInput array:");
                Console.WriteLine(string.Join(" ", insertionArray));
            }

            var sw = new Stopwatch();

            // --- Insertion Sort ---
            Console.WriteLine("\n=== Insertion Sort ===");

            // Pass 1: random input
            sw.Restart();
            InsertionSort(insertionArray);
            sw.Stop();
            Console.WriteLine($"Random input:          {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            // Pass 2: already sorted
            sw.Restart();
            InsertionSort(insertionArray);
            sw.Stop();
            Console.WriteLine($"Already sorted:        {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            // Pass 3: reverse sorted (worst case)
            Reverse(insertionArray);
            sw.Restart();
            InsertionSort(insertionArray);
            sw.Stop();
            Console.WriteLine($"Reverse sorted:        {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            // --- Shaker Sort ---
            Console.WriteLine("\n=== Shaker Sort ===");

            // Pass 1: random input
            sw.Restart();
            ShakerSort(shakerArray);
            sw.Stop();
            Console.WriteLine($"Random input:          {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            // Pass 2: already sorted
            sw.Restart();
            ShakerSort(shakerArray);
            sw.Stop();
            Console.WriteLine($"Already sorted:        {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            // Pass 3: reverse sorted (worst case)
            Reverse(shakerArray);
            sw.Restart();
            ShakerSort(shakerArray);
            sw.Stop();
            Console.WriteLine($"Reverse sorted:        {sw.Elapsed:hh\\:mm\\:ss\\.fffffff}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
