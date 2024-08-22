namespace Task_7;

abstract class Pizza
{
    public Pizza(string n)
    {
        this.Name = n;
    }
    public string Name { get; protected set; }
    public abstract int GetCost();
    public abstract string GetComposition();
}
