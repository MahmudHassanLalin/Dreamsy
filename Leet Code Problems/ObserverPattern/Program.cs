using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           SubscriberA subscriberA =new SubscriberA();
           SubscriberB subscriberB=new SubscriberB();
           Publisher publisher=new Publisher();
           publisher.Attach(subscriberA);
           publisher.Attach(subscriberB);
           publisher.DoSumBusinessLogic();
           publisher.DoSumBusinessLogic();
           publisher.Detach(subscriberB);
           publisher.DoSumBusinessLogic();
        }
    }

    interface ISubscriber//IObserver
    {
        void Update(IPublisher publisher);
    }
    interface IPublisher //ISubject
    {
        void Attach(ISubscriber subscriber);
        void Detach(ISubscriber subscriber);
        void Notify();
    }

    class Publisher:IPublisher
    {
        public int State { get; set; }
        private readonly List<ISubscriber> _subscribers=new List<ISubscriber>();
        public void Attach(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }

        public void DoSumBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }
    class SubscriberA:ISubscriber
    {
        public void Update(IPublisher pulisher)
        {
            if ((pulisher as Publisher).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }
    class SubscriberB : ISubscriber
    {
        public void Update(IPublisher pulisher)
        {
            if ((pulisher as Publisher).State == 0 || (pulisher as Publisher).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
