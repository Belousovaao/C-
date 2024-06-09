namespace Task3;

public class Customer
{
    public string FIO { get; set; }
    public Car? Car { get; set; }

    public Customer (string fio)
    {
        FIO = fio;
    }
}
