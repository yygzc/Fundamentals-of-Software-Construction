/*
 * 使用事件机制，模拟实现一个闹钟功能
 * 闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件
 * 在闹钟走时时或者响铃时，在控制台显示提示信息
 */

namespace Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            int time = 0;
            clock.Tick += (sender, args) =>
            {
                Console.WriteLine($"Tick.  Time:{time++}s");
            };

            clock.Alarm += (sender, args) =>
            {
                Console.WriteLine($"Alarm! Time:{time++}s");
            };

            clock.Start(5); // 模拟计时
        }
    }
    public class Clock
    {
        public event EventHandler Tick;
        public event EventHandler Alarm;
        public void Start(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                OnTick();
                Thread.Sleep(1000); // 等待时长为1s
            }
            OnAlarm();
        }
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty); // 若事件不为null，则调用
        }
        protected virtual void OnAlarm()
        {
            Alarm?.Invoke(this, EventArgs.Empty);
        }
    }
}
