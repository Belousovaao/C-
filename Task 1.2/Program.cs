internal class Program
{
    private static void Main(string[] args)
    {
        int sum = 0;

        Console.WriteLine("Введите число n.");

        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        
        Console.WriteLine(sum);
    }
}