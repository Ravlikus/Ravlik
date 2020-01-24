using System.Threading;
using System.Threading.Tasks;

namespace Task11_3
{

    /// <summary>
    /// Метод, отправляющий сообщение 
    /// </summary>
    /// <param name="message">Сообщение, которое будет отправлено</param>
    public delegate void MessageDelegate(string message);
    /// <summary>
    /// Метод, отправляющий сообщение по прошествию заданого времени
    /// </summary>
    /// <param name="message">Сообщение</param>
    /// <param name="time">Время в м/с</param>
    public delegate void CounterDelegate(string message, int time);

    public class Countdown
    {
        /// <summary>
        /// Триггер окончания времени
        /// </summary>
        public event MessageDelegate CountEndTrigger;

        /// <summary>
        /// Вызов срабатывания эвента в отдельном потоке
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="time">Время в м/с</param>
        public void StartCounting(string message, int time)
        {
            Task.Run(() => CountAndTrigger(message,time));
        }

        private void CountAndTrigger(string message, int time)
        {
            Thread.Sleep(time);
            CountEndTrigger?.Invoke(message);
        }
    }
}
