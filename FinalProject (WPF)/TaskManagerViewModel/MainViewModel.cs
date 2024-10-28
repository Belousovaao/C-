using System.ComponentModel;
using TaskManagerModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Diagnostics;

namespace TaskManagerViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IWindowService _windowService;
        public ICommand OpenImportantUrgentCommand { get; private set; }
        public ICommand OpenImportantNotUrgentCommand { get; private set; }
        public ICommand OpenNotImportantUrgentCommand { get; private set; }
        public ICommand OpenNotImportantNotUrgentCommand { get; private set; }

        public MainViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            OpenImportantUrgentCommand = new RelayCommand(() => OpenTaskList(TaskCategory.ImportantUrgent));
            OpenImportantNotUrgentCommand = new RelayCommand(() => OpenTaskList(TaskCategory.ImportantNotUrgent));
            OpenNotImportantUrgentCommand = new RelayCommand(() => OpenTaskList(TaskCategory.NotImportantUrgent));
            OpenNotImportantNotUrgentCommand = new RelayCommand(() => OpenTaskList(TaskCategory.NotImportantNotUrgent));
        }

        private void OpenTaskList(TaskCategory category)
        {
            Debug.WriteLine($"Открывается список задач для категории: {category}");
            _windowService.ShowTaskList(category);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
