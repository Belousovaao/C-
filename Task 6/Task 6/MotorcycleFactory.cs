namespace Task_6;

class MotorcycleFactory : TaxiFactory
{
    public override Movement CreateMovement()
    {
        return new RacingMovement(); // мчит на мотоцикл
    }

    public override Driver CreateDriver()
    {
        return new Motorcyclist(); // мотоциклист
    }
}
