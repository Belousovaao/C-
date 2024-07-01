namespace Task_4;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Manager
{
    public void ZooAnimals_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)    
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add: // если добавление
                if (e.NewItems?[0] is Animal newAnimal)
                    Console.WriteLine($"В зоопарк поступило новое животное {newAnimal.Name}");
                break;
            case NotifyCollectionChangedAction.Remove: // если удаление
                if (e.OldItems?[0] is Animal oldAnimal)
                    Console.WriteLine($"Зоопарк покинуло животное {oldAnimal.Name}");
                break;
        }
    }

    public void Feeding(Animal sender, Animal animal)
    {
        animal.Health += 10;
        Console.WriteLine($"Животное {animal.Name} накормлено");

    }
}
