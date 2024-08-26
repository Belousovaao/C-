namespace Taxi;

class RidingCarState : ICarState
{
    public void Start(Taxi taxi)
    {
        Console.WriteLine("Набирает скорость до состояния мчит");
        taxi.ChangeState(new RushingCarState());
    }
    public void Stop(Taxi taxi)
    {
        Console.WriteLine("Останавливается");
        taxi.ChangeState(new StandingCarState());
    }

    public string Say()
    {
        return "Едет";
    }
}
