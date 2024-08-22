namespace Task_7;

class Cheese : PizzaDecorator
{
    public Cheese(Pizza pizza) : base(pizza)
    {}

    public override int GetCost()
    {
        return base.GetCost() + 15;
    }

    public override string GetComposition()
    {
        return base.GetComposition() + ", сыр";
    }
}
