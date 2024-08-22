namespace Task_7;

class HawaiiPizza : Pizza
{
    private DoughBuilder _doughBuilder;
    public HawaiiPizza(DoughBuilder doughBuilder) : base ("Пицца гавайская")
    {
        _doughBuilder = doughBuilder;
        _doughBuilder.CreateDough();
        _doughBuilder.SetDougth();
    }
    
    public override int GetCost()
    {
        return 175;
    }

    public override string GetComposition()
    {
        Pizza pizza = new BasicPizzza(_doughBuilder);
        pizza = new Chicken(pizza);
        pizza = new Pineapple(pizza);
        
        return pizza.GetComposition();
    }
}
