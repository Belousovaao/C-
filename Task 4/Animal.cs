using System.IO.Pipes;
using System.Net.NetworkInformation;

namespace Task_4;

public abstract class Animal : CommonNumber, IAlive
{
    private int _health;

    public string Name { get; set; }
    public int Health
    {
        get => _health;
        set
        {
            if (value >= -10 && value <= 10)
                _health = value;
            else
                Console.WriteLine("Некорректное значение, здоровье может оцениваться от -10 до 10 баллов");
        }
    }

    public delegate void FeedingEventHandler(Animal sender, Animal animal);
    public event FeedingEventHandler? Notify;

    public Animal(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void NeedsFeeding (Animal animal)
    {
        if (Health < 0)
        {
            Notify?.Invoke(this, animal);
            {
            }
        }
    }
}
