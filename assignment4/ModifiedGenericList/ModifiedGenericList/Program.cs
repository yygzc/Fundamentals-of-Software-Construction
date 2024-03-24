/*
 * 1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法,
 * 通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）
*/

namespace ModifiedGenericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for(int x=0; x<10; x++)
            {
                list.Add(x);
            }
            //打印链表元素
            GenericList<int>.ForEach<int>(list, m => Console.WriteLine(m));

            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;

            GenericList<int>.ForEach<int>(list, 
                m =>
                {
                    sum += m;
                    if (m > max) max = m;
                    if (m < min) min = m;
                });
            Console.WriteLine($"Sum={sum} Max={max} Min={min}");
        }
    }
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);

            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public static void ForEach<T>(GenericList<T> list, Action<T> action)
        {
            Node<T> p = list.head;
            while(p != null)
            {
                action(p.Data);
                p = p.Next;
            }
        }
    }
}
