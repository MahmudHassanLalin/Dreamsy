using System;
using System.Collections.Generic;

namespace Problem9_Palindrome_Number_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           bool x= IsPalindrome(122222321);
           Console.WriteLine("is palindrome {0}",x);
        }
        static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int reverseX = reverse(x);
            if (x < 0) reverseX *= -1;
            if (x == reverseX) return true;
            return false;
        }

        static int reverse(int x)
        {
            int reminder = 0, copyX = x;
            Stack<int> stack = new Stack<int>();
            int counter = 0;
            while (copyX > 0)
            {
                reminder = copyX % 10;
                copyX /= 10;
                stack.Push(reminder);
                counter++;
            }
            int reverseX = 0;
            for (int i = 0, j = 1; i < counter; i++)
            {
                reminder = stack.Pop();
                reverseX += reminder * j;
                j *= 10;
            }

            return reverseX;
        }

        static int reverse2(int x)
        {
            int reverse = 0;
            while (x > 0)
            {
                reverse = reverse * 10 + x % 10;
                x /= 10;
            }

            return reverse;
        }
    }

}
