using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskManagerModel;
using TaskManagerViewModel;

namespace TaskManagerView
{
    public class WindowService : IWindowService
    {
        public void ShowTaskList(TaskCategory category)
        {
            Debug.WriteLine($"ShowTaskList вызван с категорией: {category}");
            try
            {
                var taskListWindow = new TaskListWindow(category);
                taskListWindow.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии окна: {ex.Message}");
            }
        }
    }
}
