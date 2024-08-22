using System.Runtime.CompilerServices;

namespace Task_7;

class CustomPizza : Pizza
{
    private DoughBuilder _doughBuilder;
    private Pizza _basePizza;

    public CustomPizza(DoughBuilder doughBuilder) : base ("Авторская пицца")
    {
        _doughBuilder = doughBuilder;
        _doughBuilder.CreateDough();
        _doughBuilder.SetDougth();
        _basePizza = new BasicPizzza(doughBuilder);
    }

    public override string GetComposition()
    {
        return _basePizza.GetComposition();
    }

    public override int GetCost()
    {
        return _basePizza.GetCost();
    }

    public Pizza BuildPizza(Pizza basePizza)
    {
        _basePizza = basePizza;
        return _basePizza;
    }
}
