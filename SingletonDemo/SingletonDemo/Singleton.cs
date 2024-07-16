using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static int count = 0;
        private Singleton()
        {
            count++;
            Console.WriteLine($"Counter number {count}");
        }

        /*
        public static Singleton GetInstance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        */


        //For multi-thread
        private static readonly object obj = new object();
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }



        public void PrintMessage(string message)
        {
        Console.WriteLine(message);
        }
    }
}
