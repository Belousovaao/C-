using Model.BL;
using Model.DAL;
using Model.Domain;
using Presenter;
using Shared;

namespace ConsoleApp1;

public class MainView : IMainView
{
    private IMainModel _model;
    public MainView(IMainModel model)
    {
        _model = model;
    }
    
    public event EventHandler<EmployeeEventArgs> EventAddEmployee;
    public event EventHandler<EmployeeEventArgs> EventDelEmployee;
    public event EventHandler EventLoudView;

    public void Run()
    {
        string? command = "";
        
        while (command != "0")
        {
            Console.Write("Выберите действие:\n");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Показать всех сотрудников");
            Console.WriteLine("0. Выход");
                
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                AddEmployee();
                break;
                    
                case "2":
                DeleteEmployee();
                break;

                case "3":
                LoudEmployees();
                break;
            }
        }
    }

        public void Add(Employee employee)
        {
            Console.WriteLine($"Сотрудник {employee.Name} добавлен.");
        }

        public void Del(Employee employee)
        {
            Console.WriteLine($"Сотрудник {employee.Name} удален.");
        }

        public void Loud(IList<Employee> employees)
        {
            Console.WriteLine("Список сотрудников:");
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.Id}: {item.Name}, Возраст: {item.Age}");
            }
        }

        private void AddEmployee()
        {
            Console.Write("Введите имя сотрудника: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст сотрудника: ");
            int age = Convert.ToInt32(Console.ReadLine());

            var employee = new Employee { Name = name, Age = age };
            EventAddEmployee?.Invoke(this, new EmployeeEventArgs(employee));
        }

        private void DeleteEmployee()
        {
            Console.Write("Введите Id для удаления сотрудника: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var employees = _model.GetEmployees();
            var employeeToDelete = employees.FirstOrDefault(item => item.Id == id);

            if (employeeToDelete != null)
            {
                EventDelEmployee?.Invoke(this, new EmployeeEventArgs(employeeToDelete));
            }
            else
            {
                Console.WriteLine("Сотрудник с указанным Id не найден.");
            }
        }
        private void LoudEmployees()
        {
            EventLoudView?.Invoke(this, EventArgs.Empty);
        }
}
