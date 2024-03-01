namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("朱奕尧 2022302111378\n");

            string s = "";
            double n1, n2, result;
            Console.Write("Please input a number: ");
            s = Console.ReadLine();
            n1 = double.Parse(s);
            Console.Write("Please input a number again: ");
            s = Console.ReadLine();
            n2 = double.Parse(s);

            Console.Write("Please input an operator: ");
            string op = Console.ReadLine();
            switch(op)
            {
                case "+":
                    result = n1 + n2;
                    Console.WriteLine($"Result: {result}", result);
                    break;
                case "-":
                    result = n1 - n2;
                    Console.WriteLine($"Result: {result}", result);
                    break;
                case "*":
                    result = n1 * n2;
                    Console.WriteLine($"Result: {result}", result);
                    break;
                case "/":
                    result = n1 / n2;
                    Console.WriteLine($"Result: {result}", result);
                    break;
                case "%":
                    result = n1 % n2;
                    Console.WriteLine($"Result: {result}", result);
                    break;
            }
        }
    }
}
