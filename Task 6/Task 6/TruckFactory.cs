namespace Task_6;

class TruckFactory : TaxiFactory
{
    public override Movement CreateMovement()
    {
        return new DraggingMovement(); // грузовой автомобиль тащится
    }

    public override Driver CreateDriver()
    {
        return new TruckDriver(); // водитель грузового автомобиля дальнобойщик
    }
}
