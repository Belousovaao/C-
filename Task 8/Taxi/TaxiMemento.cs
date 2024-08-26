namespace Taxi;

class TaxiMemento
{
    public int Passengers { get; private set; }
    public int Distance { get; private set; }
    public ICarState State { get; private set; }

    public TaxiMemento(int passengers, int distance, ICarState state)
    {
        Passengers = passengers;
        Distance = distance;
        State = state;
    }
}
