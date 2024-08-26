namespace Taxi;


internal class Program
{
    private static void Main(string[] args)
    {
        Taxi taxi1 = new Taxi(5, "Toyota Prius", new Econom(), 45, new StandingCarState());
        taxi1.Tarif = new AllInclusive();
        taxi1.Price(45);
        taxi1.Start();
        taxi1.Start();
        taxi1.Stop();
        TaxiMemento remember = taxi1.CreateMemento();
        taxi1.SetMemento(remember);
    }
}