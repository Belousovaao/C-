namespace Task_7;

class Pineapple : PizzaDecorator
{
    public Pineapple(Pizza pizza) : base(pizza)
    {}

    public override int GetCost()
    {
        return base.GetCost() + 25;
    }

    public override string GetComposition()
    {
        return base.GetComposition() + ", ананас";
    }
}
