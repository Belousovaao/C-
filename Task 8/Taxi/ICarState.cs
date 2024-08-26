namespace Taxi;

interface ICarState
{
    void Start(Taxi taxi);
    void Stop(Taxi taxi);
    string Say();
}
