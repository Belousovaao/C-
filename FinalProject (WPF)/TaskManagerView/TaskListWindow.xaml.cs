using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerModel;
using TaskManagerViewModel;

namespace TaskManagerView
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {

        private EFDataContext _context;
        private TaskCategory _category;
        public TaskListWindow(TaskCategory category)
        {
            InitializeComponent();
            _category = category;
            LoadData();
            Debug.WriteLine($"Current DataContext: {DataContext}");
            Debug.WriteLine($"Загрузка окна для категории {category}");
        }

        private void LoadData()
        {
            _context = new EFDataContext();
            try
            {
                // получаем все задачи из бд
                var tasks = _context.GetTasks();
                foreach (var task in tasks)
                {
                    Debug.WriteLine($"Задача: {task.Name}, Статус: {task.Status}");
                }
                var observableTasks = new ObservableCollection<TaskItem>(tasks);
                Debug.WriteLine($"Задачи загружены, количество: {observableTasks.Count}");
                var viewModel = new TaskListViewModel(observableTasks);
                viewModel.SetCategory(_category);
                DataContext = viewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при загрузке задач: {ex.Message}");
            }

        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is TaskItem task)
            {
                // Устанавливаем выбранную задачу
                var viewModel = this.DataContext as TaskListViewModel;
                if (viewModel != null)
                {
                    viewModel.SelectedTask = task; // Устанавливаем выбранный элемент
                }
                e.Handled = false;
                return;
            }
        }
    }
}
