namespace PrimeFactor
{
    internal class Program
    {
        public bool isPrimeNumber(int n)
        {
            for(int i = 2; i < n; i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void getPrimeFactor(int n)
        {
            if(n <= 1)
            {
                Console.WriteLine("No prime factor!");
            }
            else if (n == 2)
            {
                Console.WriteLine("2 ");
            }
            else
            {
                for(int i = 2; i <= n; i++)
                {
                    if(n % i == 0)
                    {
                        if(isPrimeNumber(i))
                        {
                            Console.WriteLine($"{i} ");
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Please input a integer: ");
            string str = Console.ReadLine();
            if(!int.TryParse(str, out num))
            {
                Console.WriteLine("Input mistake!");
            }
            else
            {
                num = int.Parse(str);
            }

            Program program = new Program();
            Console.WriteLine("Its prime factor follow as: ");
            program.getPrimeFactor(num);
        }
    }
}
