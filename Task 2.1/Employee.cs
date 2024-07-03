namespace Task_2._1;

public abstract class Employee
{
    public string Name { get; set; }
    bool IsBusy { get; } = false;

    public Employee(string fio)
    {
        Name = fio;
    }

    public virtual void OfficialDuties()
    {
        
    }
}
