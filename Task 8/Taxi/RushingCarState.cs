namespace Taxi;

class RushingCarState : ICarState
{
    public void Start(Taxi taxi)
    {
        Console.WriteLine("Продолжает мчать");
    }
    public void Stop(Taxi taxi)
    {
        Console.WriteLine("Снижает скорость до состояния едет");
        taxi.ChangeState(new RidingCarState());
    }
    public string Say()
    {
        return "Мчит";
    }
}
