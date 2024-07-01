namespace Task_4;

public abstract class Herbo : Animal
{
    private int _kindness;

    public int Kindness 
    { 
        get
        {
            return _kindness;
        }
        set
        {
            if (value >= 0 && value <= 10)
            _kindness = value;
            else
            Console.WriteLine("Некорректное значение, доброта может оцениваться от 0 до 10 баллов");
        }
    }

    public Herbo(string name, int health, int kindness) : base(name, health)
    {
        Kindness = kindness;
    }
}
