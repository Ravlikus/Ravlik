using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task11_3
{
    public delegate void MessageDelegate(string message);
    public delegate void CounterDelegate(string message, int time);
    public class Countdown
    {
        public event MessageDelegate CountEndTrigger;

        public void StartCounting(string message, int time)
        {
            Task.Run(() => CountAndTrigger(message,time));
        }

        private void CountAndTrigger(string message, int time)
        {
            Thread.Sleep(time);
            CountEndTrigger.Invoke(message);
        }
    }
}
