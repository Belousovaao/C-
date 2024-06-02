namespace Task2;

//Базовый абстрактный кл
public abstract class Animal(int age)
{
    protected int health = 9;

    public string? Name { get; init; }

    public int Age { get; init; } = age;

    public void Feed (int foodCount)
    {
        health += foodCount;
    }

    public void Punish (int punchCount)
    {
        health += punchCount;
    }

   // public string Health
    //{
    //    get 
    //    { 
    //        if (this.health >= 0 && this.health <= 50)
    //            return $"Окрас белый";
    //        else if (this.health >= 51 && this.health <= 100)
    //            return $"Окрас зелёный";
    //    }
    //}

    public virtual void Say()
    {
        if (Name == "")
            Console.WriteLine($"Привет! Дай мне имя, мне {Age} лет");
        else
            Console.WriteLine($"Привет! Меня зовут {Name}, мне {Age} лет");
    }
}
