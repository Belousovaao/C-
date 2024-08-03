using Model.BL;
using Model.Domain;

namespace Shared
{
    public interface IMainView
    {
        event EventHandler<EmployeeEventArgs> EventAddEmployee;
        event EventHandler<EmployeeEventArgs> EventDelEmployee;
        event EventHandler EventLoadView;

        void Add(Employee employee);
        void Run();
        void Del(Employee employee);
        void Loud(IList<Employee> employees);
    }
}
