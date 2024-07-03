namespace Task_2._1;

sealed class Cashier : Employee
{
    public Cashier(string fio) : base(fio)
    {
    }

    public override void OfficialDuties()
    {
        base.OfficialDuties();
    }
}





// перекрытие метода будет publc new void OfficialDuties()