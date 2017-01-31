using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadEx06
{
    public class Program
    {
        private Thread t;
        private Thread t2;
        private int counter;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            t = new Thread(PrintSymbol);
            t2 = new Thread(PrintSymbol);
            t.Start("*");
            t2.Start("#");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void PrintSymbol(object symbol)
        {
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(100);
                Console.Write(symbol);
                counter++;
            }
            Console.Write(" " + counter + "\n");
        }

    }
}
