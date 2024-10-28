using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerModel;

namespace TaskManagerViewModel
{
    public interface IWindowService
    {
        void ShowTaskList(TaskCategory category);
    }
}
