using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskManagerModel;
using TaskStatus = TaskManagerModel.TaskStatus;

namespace TaskManagerViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private TaskCategory _category;

        private ObservableCollection<TaskItem> _tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get => _tasks;
            private set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    OnPropertyChanged();
                    Debug.WriteLine($"В SelectedTabIndex установлен на: {SelectedTabIndex}");
                }
            }
        }

        private bool _isEditing;

        public bool IsEditing
        {
            get => _isEditing;
            private set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isDeleteEnabled;
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            set
            {
                if (_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        private TaskItem _selectedTask;
        public TaskItem SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged();
                    Debug.WriteLine($"SelectedTask set to: {value?.Name}, Status: {_selectedTask?.Status}");
                    ((RelayCommand)EditCommand).RaiseCanExecuteChanged(); //обновляем доступность команды редактирования
                    UpdateDeleteButtonState();
                }

            }
        }

        private ObservableCollection<TaskStatus> _availableStatuses;
        public ObservableCollection<TaskStatus> AvailableStatuses
        {
            get => _availableStatuses;
            private set
            {
                _availableStatuses = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskItem> _importantUrgentTasks;
        public ObservableCollection<TaskItem> ImportantUrgentTasks
        {
            get => _importantUrgentTasks;
            private set
            {
                _importantUrgentTasks = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<TaskItem> _importantNotUrgentTasks;
        public ObservableCollection<TaskItem> ImportantNotUrgentTasks
        {
            get => _importantNotUrgentTasks;
            private set
            {
                _importantNotUrgentTasks = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<TaskItem> _notImportantUrgentTasks;
        public ObservableCollection<TaskItem> NotImportantUrgentTasks
        {
            get => _notImportantUrgentTasks;
            private set
            {
                _notImportantUrgentTasks = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<TaskItem> _notImportantNotUrgentTasks;
        public ObservableCollection<TaskItem> NotImportantNotUrgentTasks
        {
            get => _notImportantNotUrgentTasks;
            private set
            {
                _notImportantNotUrgentTasks = value;
                OnPropertyChanged();
            }
        }
        private TaskItem _newTask;
        public TaskItem NewTask
        {
            get => _newTask ??= new TaskItem();
            set
            {
                _newTask = value;
                OnPropertyChanged();
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand => _editCommand ??= new RelayCommand(Edit);

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save);

        public ICommand CreateTaskCommand { get; set; }
        private RelayCommand _deleteTaskCommand;
        public ICommand DeleteTaskCommand
        {
            get
            {
                return _deleteTaskCommand ?? (_deleteTaskCommand = new RelayCommand(DeleteTask, () => IsDeleteEnabled));
            }
        }

        public TaskListViewModel(ObservableCollection<TaskItem> _tasks)
        {
            Tasks = _tasks;
            AvailableStatuses = new ObservableCollection<TaskStatus>(Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>());
            ImportantUrgentTasks = new ObservableCollection<TaskItem>();
            ImportantNotUrgentTasks = new ObservableCollection<TaskItem>();
            NotImportantUrgentTasks = new ObservableCollection<TaskItem>();
            NotImportantNotUrgentTasks = new ObservableCollection<TaskItem>();
            CreateTaskCommand = new RelayCommand(CreateTask);
            IsDeleteEnabled = false;
        }

        public void SetCategory(TaskCategory category)
        {
            _category = category;
            Debug.WriteLine($"Установленная категория: {_category}");
            SetCurrentTab();
            LoadTasksForCategory();
        }
        
        private void SetCurrentTab()
        {
            switch (_category)
            {
                case TaskCategory.ImportantUrgent:
                    SelectedTabIndex = 0;
                    break;
                case TaskCategory.NotImportantUrgent:
                    SelectedTabIndex = 1;
                    break;
                case TaskCategory.ImportantNotUrgent:
                    SelectedTabIndex = 2;
                    break;
                case TaskCategory.NotImportantNotUrgent:
                    SelectedTabIndex = 3; 
                    break;
                default:
                    SelectedTabIndex = -1;
                    break;
            }
        }

        private void UpdateAvailableStatuses()
        {
            if (SelectedTask != null && AvailableStatuses != null)
            {
                AvailableStatuses.Clear();
                Debug.WriteLine("Очищение доступных статусов...");
                Debug.WriteLine($"Доступные статусы: {AvailableStatuses.Count}");
                foreach (var status in Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>())
                {
                    // Проверяем, доступен ли статус для текущей задачи
                    if (SelectedTask.CanSetStatus(status))
                    {
                        AvailableStatuses.Add(status);
                        Debug.WriteLine($"Добавлен статус: {status}");
                    }
                }
                Debug.WriteLine($"Доступные статусы: {AvailableStatuses.Count}");
                Debug.WriteLine($"Текущий статус после обновления: {SelectedTask.Status}");
            }
            else
            {
                Debug.WriteLine($"Условие if не выполнено");
            }

        }

        private void LoadAvailableStatuses()
        {
            using (var context = new EFDataContext())
            {
                // Загружаем статусы из БД
                var statuses = context.TasksList.Select(task => task.Status).Distinct().ToList();
                AvailableStatuses.Clear();

                foreach (var status in statuses)
                {
                    AvailableStatuses.Add(status);
                    Debug.WriteLine($"Добавлен статус: {status}");
                }
            }
        }
        private void LoadTasksForCategory()
        {
            LoadAvailableStatuses();
            using (var context = new EFDataContext())
            {
                Debug.WriteLine($"Загрузка задач для всех категорий");

                var tasks = context.TasksList.ToList();

                Debug.WriteLine($"Найдено {tasks.Count} задач.");

                ImportantUrgentTasks.Clear();
                ImportantNotUrgentTasks.Clear();
                NotImportantUrgentTasks.Clear();
                NotImportantNotUrgentTasks.Clear();

                foreach (var task in tasks)
                {
                    if (task.Status == null)
                    {
                        task.Status = TaskStatus.Assigned; // Статус по умолчанию
                    }
                    switch (task.Category)
                    {
                        case TaskCategory.ImportantUrgent:
                            ImportantUrgentTasks.Add(task);
                            break;
                        case TaskCategory.ImportantNotUrgent:
                            ImportantNotUrgentTasks.Add(task);
                            break;
                        case TaskCategory.NotImportantUrgent:
                            NotImportantUrgentTasks.Add(task);
                            break;
                        case TaskCategory.NotImportantNotUrgent:
                            NotImportantNotUrgentTasks.Add(task);
                            break;
                    }
                }
            }
        }

        private void Edit()
        {
            if (SelectedTask != null)
            {
                Debug.WriteLine($"Редактирование задачи: {SelectedTask.Name}, текущий статус: {SelectedTask.Status}");
                UpdateAvailableStatuses();
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                IsEditing = true;
            }
        }

        public void Save()
        {
            if (SelectedTask != null)
            {
                using (var context = new EFDataContext())
                {
                    var taskToUpdate = context.TasksList.Find(SelectedTask.Id);
                    if (taskToUpdate != null)
                    {
                        taskToUpdate.Name = SelectedTask.Name;
                        taskToUpdate.Description = SelectedTask.Description;
                        taskToUpdate.Status = SelectedTask.Status;
                        taskToUpdate.Executor = SelectedTask.Executor;
                        taskToUpdate.RegistrationData = SelectedTask.RegistrationData;
                        taskToUpdate.PlanLabourIntensity = SelectedTask.PlanLabourIntensity;
                        taskToUpdate.FinishTime = SelectedTask.FinishTime;
                        context.SaveChanges();
                    }
                }
                IsEditing = false; // Выключаем режим редактирования
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private void CreateTask()
        {
            var newTask = new TaskItem()
            {
                Name = " ",
                Description = " ",
                Executor = " ",
                RegistrationData = DateTime.Now,
                PlanLabourIntensity = 0,
                FinishTime = null,
                Status = TaskStatus.Assigned
            };

            switch (SelectedTabIndex) //устанавливаем категорию на основе выбранной вкладки
            {
                case 0: // Important and Urgent
                    newTask.Category = TaskCategory.ImportantUrgent;
                    break;
                case 1: // Not Important and Urgent
                    newTask.Category = TaskCategory.NotImportantUrgent;
                    Debug.WriteLine($"В create task SelectedTabIndex установлен на: {SelectedTabIndex}");
                    break;
                case 2: // Important Not Urgent
                    newTask.Category = TaskCategory.ImportantNotUrgent;
                    break;
                case 3: // Not Important Not Urgent
                    newTask.Category = TaskCategory.NotImportantNotUrgent;
                    break;
            }
            using (var context = new EFDataContext())
            {
                context.TasksList.Add(newTask);
                context.SaveChanges(); 

                switch (SelectedTabIndex) //добавляем новую задачу в коллекцию в соответствии с категорией
                {
                    case 0: // Important and Urgent
                        ImportantUrgentTasks.Add(newTask);
                        break;
                    case 1: // Not Important and Urgent
                        NotImportantUrgentTasks.Add(newTask);
                        Debug.WriteLine($"SelectedTabIndex установлен на: {SelectedTabIndex}");
                        break;
                    case 2: // Important Not Urgent
                        ImportantNotUrgentTasks.Add(newTask);
                        break;
                    case 3: // Not Important Not Urgent
                        NotImportantNotUrgentTasks.Add(newTask);
                        break;
                }
                SelectedTask = newTask; // Автоматически выбираем новую задачу
                IsEditing = true;
                Debug.WriteLine("SelectedTabIndex: " + SelectedTabIndex);
                Debug.WriteLine("IsEditing: " + IsEditing);
                Debug.WriteLine($"Создана новая задача с ID: {newTask.Id}");
                OnPropertyChanged();
            }
        }

        private void UpdateDeleteButtonState()
        {
            // Активируем кнопку "Удалить", если есть выбранная задача
            IsDeleteEnabled = _selectedTask != null;
            Debug.WriteLine($"IsDeleteEnabled: {IsDeleteEnabled}, SelectedTask: {_selectedTask}");
            ((RelayCommand)DeleteTaskCommand).RaiseCanExecuteChanged();
        }
        private void DeleteTask()
        {
            if (SelectedTask == null)
            {
                Debug.WriteLine("Нет выбранной задачи для удаления.");
                return;
            }

            try
            {
                using (var context = new EFDataContext())
                {
                    var taskToDelete = context.TasksList.Find(SelectedTask.Id);
                    if (taskToDelete != null)
                    {
                        context.TasksList.Remove(taskToDelete);
                        context.SaveChanges();
                        Debug.WriteLine($"Задача {taskToDelete.Name} удалена.");

                        switch (SelectedTask.Category)
                        {
                            case TaskCategory.ImportantUrgent:
                                ImportantUrgentTasks.Remove(SelectedTask);
                                break;
                            case TaskCategory.ImportantNotUrgent:
                                ImportantNotUrgentTasks.Remove(SelectedTask);
                                break;
                            case TaskCategory.NotImportantUrgent:
                                NotImportantUrgentTasks.Remove(SelectedTask);
                                break;
                            case TaskCategory.NotImportantNotUrgent:
                                NotImportantNotUrgentTasks.Remove(SelectedTask);
                                break;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Задача не найдена в контексте для удаления.");
                    }
                }

                SelectedTask = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при удалении задачи: {ex.Message}");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}