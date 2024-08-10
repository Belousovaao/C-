using Model.DAL;
using Model.Domain;

namespace Model;

public abstract class AdoRepository<T> : IRepository<T>
    where T : IDomainObject, new()
{
    private readonly List<T> _added = new List<T>();
    protected List<T> Added { get { return _added;} }

    private readonly List<T> _deleted = new List<T>();
    protected List<T> Deleted { get { return _deleted;} }

    public abstract IEnumerable<T> GetAll();
    public abstract string GetUpdateScript();

    public void Delete(T entity)
    {
        if (_added.Contains(entity))
            _added.Remove(entity);
        else if (!_deleted.Contains(entity))
            _deleted.Add(entity);
    }

    public void Add(T entity)
    {
        if (_deleted.Contains(entity))
            _deleted.Remove(entity);
        else if (!_added.Contains(entity))
            _added.Add(entity);
    } 

    protected IEnumerable<int> DeletedIds
    {
        get {   return Deleted.Select(o => o.Id).Distinct(); }
    } 

    public void Discard()
    {
        Added.Clear();
        Deleted.Clear();
    }     
}
