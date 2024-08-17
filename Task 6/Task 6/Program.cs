using Task_6;

internal class Program
{
    private static void Main(string[] args)
    {
        Client car = new Client(new CarFactory());

        car.Say();
        car.Move();

        Client horse = new Client(new HorseDrawnCarriageFactory());

        horse.Say();
        horse.Move();

        Client motor = new Client(new MotorcycleFactory());

        motor.Say();
        motor.Move();

        
        Client truck = new Client(new TruckFactory());

        truck.Say();
        truck.Move();
    }
}