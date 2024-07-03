namespace Task_2._1;

public abstract class Employee
{
    public static List<Employee> listOfEmployees = new List<Employee>();
    public string Name { get; set; }
    public bool IsBusy { get; } = false;

    public Employee(string fio)
    {
        Name = fio;
        listOfEmployees.Add(this);
    }

    public virtual void OfficialDuties()
    {
        Console.WriteLine("Каждый сотрудник почты должен быть: вежливым, компетентным и оочень быстрым!");
    }
}
