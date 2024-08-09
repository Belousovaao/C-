using Model.DAL;
using Model.Domain;

namespace Model;

public interface IUnitOfWork
{
    IRepository<Employee> Emps { get; }
    bool SaveChanges();
    void Discard();
}
