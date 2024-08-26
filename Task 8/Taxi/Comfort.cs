namespace Taxi;

public class Comfort : ITarif
{
    public void Price(int distance)
    {
        Console.WriteLine($"Стоимость поездки составила {distance * 3} рублей.");
    }
}
