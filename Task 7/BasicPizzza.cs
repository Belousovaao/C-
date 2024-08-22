namespace Task_7;

class BasicPizzza : Pizza
{
    private DoughBuilder _doughBuilder;

    public BasicPizzza(DoughBuilder doughBuilder) : base ("Базовая пицца")
    {
        _doughBuilder = doughBuilder;
        _doughBuilder.CreateDough();
        _doughBuilder.SetDougth();
    }

    public override int GetCost()
    {
        return 100;
    }

    public override string GetComposition()
    {
        return $"{_doughBuilder.Dough.Type}";
    }


}
