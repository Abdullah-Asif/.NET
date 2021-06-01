using System;
using System.Threading;

namespace THREAD
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var thread1 = new Thread(OddPrint);
            var thread2 = new Thread(new ThreadStart(program.EvenPrint));
            thread2.Start();
             thread1.Start();
        }
        static void OddPrint()
        {
            for (int i = 1; i < 100; i += 2)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
         void EvenPrint()
        {
            for (int i = 0; i <= 100; i += 2)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);

            }
        }
    }
}
