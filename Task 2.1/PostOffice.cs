namespace Task_2._1;

public class PostOffice
{
    List<Employee> listOfEmployees;

    public PostOffice()
    {
        listOfEmployees = new List<Employee>();
    }

    public void Poll()
    {
        foreach (var employee in Employee.listOfEmployees)
        {
            Console.WriteLine(employee.Name);
            employee.OfficialDuties();
            if (employee.IsBusy)
            Console.WriteLine("Занят делом!");
            else if (employee is Postman postman)
            {
                if (postman.IsBusy)
                Console.WriteLine("Занят делом!");
                else
                Console.WriteLine("Свободен.");
            }
            else
            Console.WriteLine("Свободен.");
        }
    }

}






// public class FactoryAF
// {
//     List<Car> listOfCars;
//     List<Customer> listOfCustomers;

//     public FactoryAF(List<Customer> customers)
//     {
//         listOfCars = new List<Car>();
//         listOfCustomers = customers;
//     }

//     public void CreateCar()
//     {
//         Car newCar = new Car();
//         listOfCars.Add(newCar);
//     }
