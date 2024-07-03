namespace Task_4;

public abstract class CommonNumber : IInventory
{
    private static int nextNumber = 1;

     public int Number { get; set; }

    public CommonNumber() => Number = nextNumber++;
}
