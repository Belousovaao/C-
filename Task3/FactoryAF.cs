using System.Security.Cryptography.X509Certificates;

namespace Task3;

public class FactoryAF
{
    public List<Customer> ListOfCustomers { get; set; }
    private List<Car> listOfCars;


    public FactoryAF()
    {
        ListOfCustomers = new List<Customer>();
        listOfCars = new List<Car>();
    }

    public void CreateCar(Car car)
    {
        listOfCars.Add(car);
    }

    public void SaleCar()
    {
        foreach (var customer in ListOfCustomers)
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
        Console.WriteLine($"Сейчас на складе МФТИ имеется {listOfCars.Count} автомобилей, а список покупателей состоит из {ListOfCustomers.Count} человек.");
    }
}
