namespace Task_2._1;

sealed class Operator : Employee
{
    public Operator(string fio) : base(fio)
    {
    }
    
    public override void OfficialDuties()
    {
        base.OfficialDuties();
        Console.WriteLine("Оператор почты должен иметь навык работы с компьютером, быстро печатать и быть стрессоустойчивым!");
    }
}
