namespace Task_7;

abstract class DoughBuilder
{
    public Dough Dough{ get; set; }

    public void CreateDough()
    {
        Dough = new Dough("");
    }

    public abstract void SetDougth();
}
