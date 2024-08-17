namespace Task_6;

abstract class TaxiFactory
{
    public abstract Movement CreateMovement();
    public abstract Driver CreateDriver();
}
