namespace Task_6;

class HorseDrawnCarriageFactory : TaxiFactory
{
    public override Movement CreateMovement()
    {
        return new RidingMovement(); // скачет на гужевой повозке
    }

    public override Driver CreateDriver()
    {
        return new Coachman(); // кучер
    }
}
