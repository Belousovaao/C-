namespace Taxi;

public class Econom : ITarif
{
    public void Price(int distance)
    {
        Console.WriteLine($"Стоимость поездки составила {distance * 2} рублей.");
    }
}
