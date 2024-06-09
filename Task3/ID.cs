using System.Dynamic;

namespace Task3;

public abstract class DomainObject
{
    private static int nextId = 1;
    public int Id { get; }

    public DomainObject()
    {
        this.Id = nextId;
        nextId++;
    }
}

