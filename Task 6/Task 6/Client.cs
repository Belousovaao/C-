namespace Task_6;

class Client
{
    private Driver driver;
    private Movement movement;

    public Client(TaxiFactory taxiFactory)
    {
        driver = taxiFactory.CreateDriver();
        movement = taxiFactory.CreateMovement();
    }

    public void Say()
    {
        driver.Say();
    }

    public void Move()
    {
        movement.Move();
    }
}
