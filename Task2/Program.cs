using System.Data.Common;
using System.Security.Cryptography;
using Task2;

internal class Program
{
    private static void Main(string[] args)
    {
       Animal[] animals = [new Cat(3), new Dog(2)];
       foreach (var animal in animals)
       {
       if (animal is Cat cat1)
        cat1.Say();
       else if (animal is Dog dog1)
        dog1.Say();
       }


    }
}