using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        int quantityOfBoxes = 50;
        
        while (quantityOfBoxes > 0)
        {
            Console.WriteLine("Сколько ящиков готова забрать машина?");

            int boxes = Convert.ToInt32(Console.ReadLine());

            if (boxes <= quantityOfBoxes)
            {
                quantityOfBoxes -= boxes;
            }
            else
            {
                Console.WriteLine($"На складе такого количества нет, отгруажем {quantityOfBoxes} коробок");
                quantityOfBoxes = 0;
            }
        }
    }
}