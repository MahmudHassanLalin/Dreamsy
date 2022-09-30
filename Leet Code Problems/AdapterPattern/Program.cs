using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ICalculator calc=new AdapterCalculator(new Adaptee());
            calc.AddTwoData(10, 20);
        }

        interface ICalculator
        {
            int AddTwoData(int a, int b);
        }

        class AdapterCalculator : ICalculator
        {
            private Adaptee _adaptee;

            public AdapterCalculator(Adaptee adaptee)
            {
                this._adaptee = adaptee;
            }
            public int AddTwoData(int a, int b)
            {
                return Convert.ToInt16(_adaptee.AddTwoData(a.ToString(), b.ToString()));
            }
        }

        class Adaptee
        {
            public string AddTwoData(string a, string b)
            {
                return (Convert.ToInt16(a) + Convert.ToInt16(b)).ToString();
            }
        }
    }
}
