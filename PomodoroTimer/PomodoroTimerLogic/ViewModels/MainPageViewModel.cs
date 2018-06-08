using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerLogic.ViewModels
{
    public class MainPageViewModel
    {
        public TaskToCompleteListViewModel TaskToCompleteListViewModel { get; set; }

        public MainPageViewModel()
        {
            this.TaskToCompleteListViewModel = new TaskToCompleteListViewModel();

            this.addNewTasks();
        }

        private void addNewTasks()
        {
            for(int i = 0; i < 3; i++)
            {
                this.TaskToCompleteListViewModel.AddTaskToComplete();
            }
        }
    }
}
