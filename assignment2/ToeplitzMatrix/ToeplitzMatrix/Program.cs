namespace ToeplitzMatrix
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please input M of M x N Matrix: ");
            int M = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Please input N of M x N Matrix: ");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input a M x N Matrix: ");
            int[,] matrix = new int [M,N];

            for(int i = 0; i < M; i++)
            {
                string[] str = Console.ReadLine().Split('｜', ' ');
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = int.Parse(str[j]);
                }
            }

            bool flag = true;
            for(int i  = 0; i < M-1; i++)
            {
                for(int j = 0; j < N-1; j++)
                {
                    if (matrix[i, j] != matrix[i + 1, j + 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }

            if(flag)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
