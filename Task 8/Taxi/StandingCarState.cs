namespace Taxi;

class StandingCarState : ICarState
{
    public void Start(Taxi taxi)
    {
        Console.WriteLine("Начинает ехать");
        taxi.ChangeState(new RidingCarState());
    }
    public void Stop(Taxi taxi)
    {
        Console.WriteLine("Продолжает стоять");
    }
    public string Say()
    {
        return "Стоит";
    }
}
