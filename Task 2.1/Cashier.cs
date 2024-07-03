namespace Task_2._1;

sealed class Cashier : Employee
{
    public Cashier(string fio) : base(fio)
    {
    }

    public override void OfficialDuties()
    {
        base.OfficialDuties();
        Console.WriteLine("Кассир почты должен быть очень внимательным, честным и бескорыстным!");
    }
}





// перекрытие метода будет publc new void OfficialDuties()