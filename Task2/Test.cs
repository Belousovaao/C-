using System.Data.Common;
using System.Security.Cryptography;
using Task2;

internal class Test
{
    private static void Main(string[] args)
    {
       Animal[] animals = [new Cat (2), new Dog(3)];
       foreach (var animal in animals)
       {
       if (animal is Cat cat1)
        {
            cat1.Say();
            cat1.Name = "Муся";
            cat1.Say();
            //cat1.Age = 5; - ошибка! возраст менять нельзя!
            cat1.Name = "1"; // Вызывает фразу, что имя изменить нельзя, команда не будет выполнена
            cat1.Feed(50);
            cat1.Punish(5);
            Console.WriteLine(cat1.Health);
            Console.ResetColor();
        }
       
       else if (animal is Dog dog1)
        {
            dog1.Say();
            dog1.Name = "Шарик";
            dog1.Say();
            //dog1.Age = 5; - ошибка! возраст менять нельзя!
            dog1.Name = "1"; // Вызывает фразу, что имя изменить нельзя, команда не будет выполнена
            dog1.Feed(3);
            dog1.Punish(5);
            Console.WriteLine(dog1.Health);
            Console.ResetColor();
        }
       }
    }
}