namespace Task_7;

class Souce : PizzaDecorator
{
    public Souce(Pizza pizza) : base(pizza)
    {}

    public override int GetCost()
    {
        return base.GetCost() + 10;
    }

    public override string GetComposition()
    {
        return base.GetComposition() + ", соус";
    }
}
