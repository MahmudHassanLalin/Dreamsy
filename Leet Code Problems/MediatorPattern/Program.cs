using System;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           Component1 component1=new Component1();
           Component2 component2=new Component2();
           new ConcreateMediator(component1,component2);
           Console.WriteLine("Client Trigger Operation A");
           component1.DoA();
           Console.WriteLine("Client Trigger Operation D");
           component2.DoD();
        }
    }

    interface IMediator
    {
        public void Notify(string sender);
    }

    class ConcreateMediator:IMediator
    {
        private Component1 _component1;
        private Component2 _component2;

        public ConcreateMediator(Component1 component1,Component2 component2)
        {
            _component1 = component1;
            _component1.Mediator = this;
            _component2 = component2;
            _component2.Mediator = this;
        }
        public void Notify(string sender)
        {
            switch (sender)
            {
                case "A":
                    Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                    _component2.DoC();
                    break;
                case "D":
                    Console.WriteLine("Mediator reacts on D and triggers following operations:");
                    this._component1.DoB();
                    this._component2.DoC();
                    break;

            }
        }
    }

    class Component1:BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");
            Mediator.Notify("A");
        }
        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");
            Mediator.Notify("B");
        }
    }
    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this.Mediator.Notify("C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this.Mediator.Notify( "D");
        }
    }

    class BaseComponent
    {
       
        public BaseComponent(IMediator mediator=null)
        {
            this.Mediator = mediator;
        }

        internal IMediator Mediator { get; set; }
    }
}
