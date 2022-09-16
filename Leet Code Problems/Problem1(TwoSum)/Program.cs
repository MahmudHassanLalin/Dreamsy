using System;

namespace Problem1_TwoSum_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length && nums.Length >= 2; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target) return new int[2] { i, j };
                }
            }
            return new int[2] { -1, -1 };
        }
    }
}
