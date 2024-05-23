internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 35; i < 87; i++)
        {
            if (i % 7 == 1 | i % 7 == 2 | i % 7 == 5)
            {
                Console.WriteLine(i);
            }
        }
    }
}