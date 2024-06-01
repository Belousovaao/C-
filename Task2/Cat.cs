namespace Task2;

public class Cat(int age) : Animal(age)
{
    public override void Say()
    {
        base.Say();
        Console.WriteLine("Мяу");
    }
}
