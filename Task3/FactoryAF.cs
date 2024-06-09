using System.Security.Cryptography.X509Certificates;

namespace Task3;

public class FactoryAF
{
    List<Car> listOfCars;
    List<Customer> listOfCustomers;

    public FactoryAF(List<Customer> customers)
    {
        listOfCars = new List<Car>();
        listOfCustomers = customers;
    }

    public void CreateCar()
    {
        Car newCar = new Car();
        listOfCars.Add(newCar);
    }

    public void SaleCar()
    {
        foreach (var customer in listOfCustomers)
        {
            if (listOfCars.Count > 0)
            {
                Car carToSell = listOfCars[0];
                customer.Car = carToSell;
                Console.WriteLine($"{customer.FIO} приобрёл автомобиль с педальным механизмом с серийныйм номером {carToSell.Id}");
                listOfCars.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Извините, автомобили закончились");
            }
         }
         listOfCars.Clear();
    
    }

    public void Say()
    {
        Console.WriteLine($"Сейчас на складе МФТИ имеется {listOfCars.Count} автомобилей, а список покупателей состоит из {listOfCustomers.Count} человек.");
    }
}
