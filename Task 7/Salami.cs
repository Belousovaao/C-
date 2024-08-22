namespace Task_7;

class Salami : PizzaDecorator
{
    public Salami(Pizza pizza) : base(pizza)
    {}

    public override int GetCost()
    {
        return base.GetCost() + 30;
    }

    public override string GetComposition()
    {
        return base.GetComposition() + ", салями";
    }
}
