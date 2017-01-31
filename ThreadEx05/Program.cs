using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadEx05
{
    public class Program
    {
        private Thread t;
        private Thread t2;
        private static int counter = 0;
        private static object o = counter; 
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            t = new Thread(AddToCount);
            t2 = new Thread(AddToCount);
            t.Start(-1);
            t2.Start(2);
        }

        private void AddToCount(object c)
        {
            for (int i = 0; i < 1000; i++) { 
                Thread.Sleep(1000);
                Monitor.Enter(o);
                try
                {
                    counter = (int)counter + (int)c;
                }
                finally
                {
                    Monitor.Exit(o);
                }
                Console.WriteLine(counter);
            }
       
        }

    }
}
