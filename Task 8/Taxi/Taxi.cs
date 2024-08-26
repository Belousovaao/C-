using System.Security.Cryptography;

namespace Taxi;

class Taxi
{
    protected int passengers;
    protected string model;
    protected int distance;
    private ICarState State;

    public Taxi(int num, string model, ITarif tarif, int distance, ICarState cs)
    {
        this.passengers = num;
        this.model = model;
        this.distance = distance;
        Tarif = tarif;
        Price(distance);
        State = cs;
    }

    public ITarif Tarif { private get; set; }

    public void Price(int distance)
    {
        Tarif.Price(distance);
    }

    public void Start()
    {
        State.Start(this);
    }

    public void Stop()
    {
        State.Stop(this);
    }

    public void SetMemento(TaxiMemento memento)
    {
        this.State = memento.State;
        this.distance = memento.Distance;
        this.passengers = memento.Passengers;

        Console.WriteLine($"Последнее сохранение: машина на {memento.Passengers} пассажиромест, дистанция - {memento.Distance} км, состояние - {memento.State.Say()}.");
    }

    public TaxiMemento CreateMemento()
    {
        return new TaxiMemento(passengers, distance, State);
    }
    public void ChangeState(ICarState carState)
    {
        State = carState;
    }
}
