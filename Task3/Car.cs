namespace Task3;

public class Car : DomainObject
{
    public Engine engine;
    public Car()
    {
        engine = new Engine();
    }
    public int Number
    {
        get => Id;
        set => Number = Id;
    }
}
