namespace Task2;

public class Dog(int age) : Animal(age)
{
    public override void Say()
    {
        base.Say();
        Console.WriteLine("Гав");
    }
}
