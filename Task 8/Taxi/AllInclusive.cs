namespace Taxi;

public class AllInclusive : ITarif
{
    public void Price(int distance)
    {
        Console.WriteLine($"Стоимость поездки составила {distance * 5} рублей.");
    }
}
