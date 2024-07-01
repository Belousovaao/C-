namespace Task_4;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

public class Zoo
{
    Manager manager;
    public ObservableCollection<Animal> ZooAnimals = new ObservableCollection<Animal>();
    public Zoo (Manager manager)
    {
        this.manager = manager;
        ZooAnimals = new ObservableCollection<Animal>();
        ZooAnimals.CollectionChanged += manager.ZooAnimals_CollectionChanged;
    }
    public void CheckAnimal (Animal animal)
    {
        if (animal.Health < -4)
        {
            Console.WriteLine($"Животное {animal.Name} слишком больно, мы не можем принять его в наш зоопарк.");
        }
        else if (animal is Herbo && ((Herbo)animal).Kindness < 5)
        {
            Console.WriteLine($"Животное {animal.Name} слишком агрессивное, мы не можем принять его в наш зоопарк.");
        }
        else
        {
            ZooAnimals.Add(animal);
            animal.Notify += manager.Feeding;
            animal.NeedsFeeding(animal);
        }


    }

    public void RemoveAnimal (Animal animal)
    {
        ZooAnimals.Remove(animal);
        animal.Notify -= manager.Feeding;
    }
}
