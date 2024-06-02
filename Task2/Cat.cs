namespace Task2;

public class Cat(int age) : Animal(age)
{
    public override void Say()
    {
        base.Say();
        Console.WriteLine("Мяу");
    }
    
    public override void Feed(int foodCount) => base.Feed(foodCount);
    public override void Punish(int punchCount) => base.Punish(punchCount);
}
