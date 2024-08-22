namespace Task_7;

class Chicken : PizzaDecorator
{
    public Chicken(Pizza pizza) : base(pizza)
    {}

    public override int GetCost()
    {
        return base.GetCost() + 50;
    }

    public override string GetComposition()
    {
        return base.GetComposition() + ", курица";
    }
}
