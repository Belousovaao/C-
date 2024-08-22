namespace Task_7;

class PepperoniPizza : Pizza
{
    private DoughBuilder _doughBuilder;
    public PepperoniPizza(DoughBuilder doughBuilder) : base ("Пицца пепперони")
    {
        _doughBuilder = doughBuilder;
        _doughBuilder.CreateDough();
        _doughBuilder.SetDougth();
    }
    
    public override int GetCost()
    {
        return 130;
    }

    public override string GetComposition()
    {
        Pizza pizza = new BasicPizzza(_doughBuilder);
        pizza = new Salami(pizza);
        
        return pizza.GetComposition();
    }
}
