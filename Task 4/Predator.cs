using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace Task_4;

public abstract class Predator : Animal
{
    public string TypeOfFood { get; set; }

    public Predator(string name, int health, string typeOfFood) : base(name, health) => TypeOfFood = typeOfFood;
}
