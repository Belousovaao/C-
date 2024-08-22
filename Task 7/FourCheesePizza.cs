namespace Task_7;

class FourCheesePizza : Pizza
{
    private DoughBuilder _doughBuilder;
    public FourCheesePizza(DoughBuilder doughBuilder) : base ("Пицца 4 сыра")
    {
        _doughBuilder = doughBuilder;
        _doughBuilder.CreateDough();
        _doughBuilder.SetDougth();
    }
    
    public override int GetCost()
    {
        return 260;
    }

    public override string GetComposition()
    {
        Pizza pizza = new BasicPizzza(_doughBuilder);
        pizza = new Cheese(pizza);
        pizza = new Cheese(pizza);
        pizza = new Cheese(pizza);
        pizza = new Cheese(pizza);

        return pizza.GetComposition();
    }
}
