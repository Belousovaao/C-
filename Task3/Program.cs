using Task3;

internal class Program
{
    private static void Main(string[] args)
    {
        FactoryAF factory = new FactoryAF();

        factory.CreateCar(new Car());
        factory.CreateCar(new Car());
        factory.CreateCar(new Car());
        factory.CreateCar(new Car());
        factory.CreateCar(new Car());
        
        factory.ListOfCustomers.Add(new Customer("Петров Иван Иванович"));
        factory.ListOfCustomers.Add(new Customer("Иванова Мария Михайловна"));
        factory.ListOfCustomers.Add(new Customer("Васильев Михаил Игоревич"));
        
        factory.Say();
        factory.SaleCar();
        factory.Say();
    }
}