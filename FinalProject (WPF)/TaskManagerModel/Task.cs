using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TaskManagerModel
{
    public class TaskItem : IDomainObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Executor { get; set; } //исполнитель
        public DateTime RegistrationData {get; set;} //дата создания задачи
        public TaskStatus Status { get; set;} 
        public int PlanLabourIntensity { get; set;} //трудозатраты план
        public DateTime? FinishTime { get; set;}
        public int? FactLeadTime //трудозатраты факт = finishtime - registrationdata
        {
            get
            {
                if (FinishTime.HasValue)
                {
                    return (int)(FinishTime.Value - RegistrationData).TotalHours;
                }
                return null;
            }
            set { }
        }
        public TaskCategory Category { get; set;}

        public void SetStatus(TaskStatus newStatus)
        {
            if (CanSetStatus(newStatus))
            {
                Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException($"Невозможно перейти к статусу {newStatus} из текущего статуса {Status}.");
            }
        }

        public bool CanSetStatus(TaskStatus newStatus)
        {
            switch (Status)
            {
                case TaskStatus.Assigned:
                    return newStatus == TaskStatus.InProgress; // Можно перейти только в InProgress
                case TaskStatus.InProgress:
                    return newStatus == TaskStatus.Paused || newStatus == TaskStatus.Completed; // Можно перейти в Paused или Completed
                case TaskStatus.Paused:
                    return newStatus == TaskStatus.InProgress; // Можно вернуться в InProgress
                case TaskStatus.Completed:
                    return false; // Нельзя изменять статус, если задача завершена
                default:
                    return false;
            }
        }
    }

    public enum TaskCategory
    {
        ImportantUrgent,
        NotImportantUrgent,
        ImportantNotUrgent,
        NotImportantNotUrgent
    }

    public enum TaskStatus
    {
        Assigned,
        InProgress,
        Paused,
        Completed
    }
}
