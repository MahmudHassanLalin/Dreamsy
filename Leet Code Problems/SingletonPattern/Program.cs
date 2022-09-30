using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Singleton.Instance.ShowStatus();
        }
    }

    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance=new Singleton();
                }

                return _instance;
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine("this is Singleton Pattern");
        }
    }
}
