using System;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Console.WriteLine(string.Join(", ", InsertionSort(input).Select(u => u.ToString())));
        }

        static int[] InsertionSort(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                int key = input[i];
                int j = i - 1;
                while (j >= 0 && key < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = key;
            }
            return input;
        }
    }
}
