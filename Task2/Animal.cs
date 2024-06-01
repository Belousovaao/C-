namespace Task2;

public abstract class Animal(int age)
{
    protected int health = 9;

    public string Name { get; init; } = "";

    public int Age { get; init; } = age;

    public void Feed (int foodCount)
    {
        health += foodCount;
    }

    public void Punish (int punchCount)
    {
        health += punchCount;
    }

    public virtual void Say()
    {
        Console.WriteLine($"Привет! Меня зовут {Name}, мне {Age} лет");
    }
}
