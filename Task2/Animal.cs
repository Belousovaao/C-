namespace Task2;

//Базовый абстрактный кл
public abstract class Animal(int age)
{
    protected int health = 9;
    private string? name;
    private bool isNameSet = false;

    public string? Name
    {
        get => name;
        set
        {
            if (!isNameSet)
            {
                name = value;
                isNameSet = true;
            }
            else
            {
                Console.WriteLine("Имя уже задано!");
            }
        }
    }

    public int Age { get; init; } = age;

    public string Health // реализация через свойство, т.к. речь идет о данных
    // если бы манипуляции производились с какими-то действиями, выбрала бы метод
    {
        get 
        { 
            if (health >= 0 && health <= 50)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return "Окрас белый"; 
                }
            else if (health >= 51 && health <= 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Окрас зелёный";
                }
            else
                {
                    return "Такое значение невозможно! Видимо, вы перекормили свою кошку";
                }
        }
    }

    public virtual void Say()
    {
        if (Name is null)
            Console.WriteLine($"Привет! Дай мне имя, мне {Age} лет");
        else
            Console.WriteLine($"Привет! Меня зовут {Name}, мне {Age} лет");
    }
    
    public virtual void Feed(int foodCount) => health += foodCount;
    public virtual void Punish(int punchCount) => health -= punchCount;
}