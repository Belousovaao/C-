namespace Task_6;

class CarFactory : TaxiFactory
{
    public override Movement CreateMovement()
    {
        return new DrivingMovement(); // легковой автомобиль едет
    }

    public override Driver CreateDriver()
    {
        return new Chauffeur(); // шофёр легкового автомобиля
    }
}
