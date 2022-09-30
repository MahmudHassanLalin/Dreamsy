using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           Client client=new Client();
           RealSubject realSubject = new RealSubject();
           client.ClientCode(realSubject);
           
           ProxySubject proxy=new ProxySubject(realSubject);
           client.ClientCode(proxy);
        }
    }

    interface ISubject
    {
        void DoRequest();
    }

    class RealSubject:ISubject
    {
        public void DoRequest()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }
      class Client
    {
        // The client code is supposed to work with all objects (both subjects
        // and proxies) via the Subject interface in order to support both real
        // subjects and proxies. In real life, however, clients mostly work with
        // their real subjects directly. In this case, to implement the pattern
        // more easily, you can extend your proxy from the real subject's class.
        public void ClientCode(ISubject subject)
        {
            subject.DoRequest();
        }
    }
    class ProxySubject:ISubject
    {
        private RealSubject _realSubject;

        public ProxySubject(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }
        public void DoRequest()
        {
            if (CheckAccess())
            {
                _realSubject.DoRequest();
                LogAccess();
            }
        }
        public bool CheckAccess()
        {
            // Some real checks should go here.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }
}
