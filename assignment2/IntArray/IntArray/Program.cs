namespace IntArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 0, min = 0;
            double average = 0, sum = 0;

            Console.WriteLine("Please input your integer array with number isolated by “,”: ");
            string[] input = Console.ReadLine().Split(',');
            int[] array = new int[input.Length];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(input[i]);
                sum += array[i];
                if(i == 0)
                {
                    max = min = array[i];
                }
                else
                {
                    if(max < array[i])
                    {
                        max = array[i];
                    }
                    if(min > array[i])
                    {
                        min = array[i];
                    }
                }
            }
            average = sum / array.Length;
            Console.WriteLine($"To this array, max: {max} min: {min} average: {average} sum: {sum}");
        }
    }
}
