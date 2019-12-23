using System;

namespace Task11_3
{
    class Program
    {
        private delegate void MsgDelegate(string msg);

        static void Main()
        {
            var counter = new Countdown();
            MessageDelegate firstMethod = (x) => { Console.WriteLine($"First method message:{x}"); };
            MessageDelegate secondMethod = (x) => { Console.WriteLine($"Second method message:{x}"); };
            counter.CountEndTrigger += firstMethod;
            counter.CountEndTrigger += secondMethod;
            counter.StartCounting("First call",1000);
            counter.StartCounting("Second call", 500);
            Console.ReadKey();
        }
    }
}
