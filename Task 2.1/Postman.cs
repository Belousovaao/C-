namespace Task_2._1;

sealed class Postman : Employee
{
    public new bool IsBusy {get; set; }
    
    public Postman(string fio) : base(fio)
    {
    }
    
    public override void OfficialDuties()
    {
        base.OfficialDuties();
        Console.WriteLine("Каждый почтальон должен иметь хорошую физическую подготовку и обожать мультфильм \"Простоквашино\"!");
    }
}
