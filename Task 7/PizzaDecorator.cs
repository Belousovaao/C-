namespace Task_7;

abstract class PizzaDecorator : Pizza
{
    protected Pizza _pizza;

    public PizzaDecorator(Pizza pizza) : base (pizza.Name)
    {
        _pizza = pizza;
    }

    public override int GetCost()
    {
        return _pizza.GetCost();
    }

    public override string GetComposition()
    {
        return _pizza.GetComposition();
    }
}
