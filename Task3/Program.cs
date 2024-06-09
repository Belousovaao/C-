using Task3;

internal class Program
{
    private static void Main(string[] args)
    {
        Customer customer1 = new Customer("Петров Иван Иванович");
        Customer customer2 = new Customer("Иванова Мария Михайловна");
        Customer customer3 = new Customer("Васильев Михаил Игоревич");

        List<Customer> customers = [customer1, customer2, customer3];
        
        FactoryAF factory = new FactoryAF(customers);

        factory.CreateCar();
        factory.CreateCar();
        factory.CreateCar();
        factory.CreateCar();
        factory.CreateCar();
        
        factory.Say();
        factory.SaleCar();
        factory.Say();
    }
}