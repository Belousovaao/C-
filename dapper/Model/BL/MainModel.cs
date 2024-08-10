using Model.DAL;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class MainModel : IMainModel
    {
        private readonly UnitOfWork _unitOfWork;
        public MainModel()
        {
            _unitOfWork = new UnitOfWork();
        }

        public event EventHandler<EmployeeEventArgs> EventAddEmployee; //= delegate { };
        public event EventHandler<EmployeeEventArgs> EventDelEmployee; //= delegate { };

        public void AddEmployee(Employee employee)
        {
            _unitOfWork.Emps.Add(employee);
            bool result = _unitOfWork.SaveChanges();
            if (result)
            {
                EventAddEmployee?.Invoke(this, new EmployeeEventArgs(employee));
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            _unitOfWork.Emps.Delete(employee);
            bool result = _unitOfWork.SaveChanges();
            if (result)
            {
                EventDelEmployee?.Invoke(this, new EmployeeEventArgs(employee));
            }
        }

        public IList<Employee> GetEmployees()
        {
            return _unitOfWork.Emps.GetAll().ToList();
        }

    }
}
