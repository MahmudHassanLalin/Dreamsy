using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Context context = new Context {Strategy = new AscendingSortStrategy()};
            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SortData();
            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.Strategy = new DescendingSortStrategy();
            context.SortData();
        }
    }

    class Context
    {
        public Istrategy Strategy { get; set; }

        public void SortData()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            var result = this.Strategy.Sort(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }
    interface Istrategy
    {
        object Sort(object data);
    }

    class AscendingSortStrategy : Istrategy
    {
        public object Sort(object data)
        {
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }
    class DescendingSortStrategy : Istrategy
    {
        public object Sort(object data)
        {
            var list = data as List<string>;
            list.Reverse();
            return list;
        }
    }
}
