using Task_4;

internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager();
        Zoo zoo = new Zoo(manager);
        Animal monkey1 = new Monkey("Banana", -2, 5);
        Animal monkey2 = new Monkey("Angra", 10, 0);
        Animal tiger1 = new Tiger("Sherhan", 9, "Meat");
        Animal tiger2 = new Tiger("Kitty", -5, "Meat");
        Animal rabbit1 = new Rabbit("Crazy", 0, 0);
        Animal rabbit2 = new Rabbit("Fluffy", 5, 8);
        Animal wolf1 = new Wolf("Akita", -1, "Meat");
        Animal wolf2 = new Wolf("Woowoo", -8, "Meat");
        zoo.CheckAnimal(monkey1);
        zoo.CheckAnimal(monkey2);
        zoo.CheckAnimal(tiger1);
        zoo.CheckAnimal(tiger2);
        zoo.CheckAnimal(rabbit1);
        zoo.CheckAnimal(rabbit2);
        zoo.CheckAnimal(wolf1);
        zoo.CheckAnimal(wolf2);
        zoo.ZooAnimals.Remove(wolf1);
    }
}