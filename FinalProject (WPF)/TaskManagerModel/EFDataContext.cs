using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;

namespace TaskManagerModel
{
    public class EFDataContext : DbContext
    {
        public DbSet<TaskItem> TasksList { get; set; }
        public EFDataContext() : base("Data Source=DESKTOP-DLAM3B7; Initial Catalog= TaskTable; Integrated Security=True")
        { }
        public ObservableCollection<TaskItem> GetTasks()
        {
            var tasks = TasksList.ToList();
            Debug.WriteLine($"Количество задач для возврата: {tasks.Count}"); // Отладочное сообщение
            return new ObservableCollection<TaskItem> (tasks);
        }
    }
}