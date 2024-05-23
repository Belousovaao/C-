internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите ширину прямоугольника.");
        int width_p = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину прямоугольника.");
        int length_p = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Периметр прямоугольника равен {width_p * 2 + length_p * 2}");
        Console.WriteLine($"Площадь прямоугольника равна {width_p * length_p}");
    }
}