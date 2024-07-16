using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDemo
{
    internal class Program
    {
        /* 
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance;
            s1.PrintMessage("Hey");
            Singleton s2 = Singleton.GetInstance;
            s2.PrintMessage("There");
        }
        */



        //For Multi-Threads
        static void Main(string[] args)
        {
            Parallel.Invoke(
            () => p1(),
            () => p2()
            );
        }
        private static void p2()
        {
            Singleton s2 = Singleton.GetInstance;
            s2.PrintMessage("There");
        }

        private static void p1()
        {
            Singleton s1 = Singleton.GetInstance;
            s1.PrintMessage("Hey");
        }



    }
}
