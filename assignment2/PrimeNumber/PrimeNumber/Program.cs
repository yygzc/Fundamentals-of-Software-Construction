namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime numbers from 2 to 100: ");
            int tmp = 0;

            for (int i = 3; i < 100; i++)
            {
                bool flag = true;
                for (int j = 2; j < i; j++)
                {
                    tmp = j;
                    while (tmp <= i)
                    {
                        if (i % tmp == 0)
                        {
                            flag = false;
                            break;
                        }
                        tmp *= j;
                    }
                    if(!flag)
                    {
                        break;
                    }
                }
                if(flag)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
