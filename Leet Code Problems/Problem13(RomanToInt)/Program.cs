using System;

namespace Problem13_RomanToInt_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int RomanToInt(string s)
        {
            int integer = 0;
            bool skip = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }
                if (s[i] == 'I')
                {
                    if ((i + 1) != s.Length && (s[i + 1] == 'V'))
                    {
                        integer += 4;
                        skip = true;
                    }
                    else if ((i + 1) != s.Length && (s[i + 1] == 'X'))
                    {
                        integer += 9;
                        skip = true;
                    }
                    else
                    {
                        integer += 1;
                    }
                }
                else if (s[i] == 'X')
                {
                    if ((i + 1) != s.Length && (s[i + 1] == 'L'))
                    {
                        integer += 40;
                        skip = true;
                    }
                    else if ((i + 1) != s.Length && (s[i + 1] == 'C'))
                    {
                        integer += 90;
                        skip = true;
                    }
                    else
                    {
                        integer += 10;
                    }
                }
                else if (s[i] == 'C')
                {
                    if ((i + 1) != s.Length && (s[i + 1] == 'D'))
                    {
                        integer += 400;
                        skip = true;
                    }
                    else if ((i + 1) != s.Length && (s[i + 1] == 'M') {
                        integer += 900;
                        skip = true;
                    }
                    else
                    {
                        integer += 100;
                    }
                }
                else if (s[i] == 'V')
                {
                    integer += 5;
                }
                else if (s[i] == 'L')
                {
                    integer += 50;
                }
                else if (s[i] == 'C')
                {
                    integer += 100;
                }
                else if (s[i] == 'D')
                {
                    integer += 500;
                }
                else if (s[i] == 'M')
                {
                    integer += 1000;
                }

            }
            return integer;
        }
        public int AnotherApproachRomanToInt(string s)
        {
            int integer = 0;
            int num = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case 'I':
                         
                        num = 1;
                        break;
                    case 'V':
                       
                        num = 5;
                        break;
                    case 'X':
                        
                        num = 10;
                        break;
                    case 'L':
                         
                        num = 50;
                        break;
                    case 'C':
                       
                        num = 100;
                        break;
                    case 'D':
                         
                        num = 500;
                        break;
                    case 'M':
                        
                        num = 1000;
                        break;
                }
                if (integer > num*4) integer -= num;
                else integer += num;
            }
            return integer;
        }
    }
    
}
