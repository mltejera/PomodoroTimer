using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerListViewModel : ViewModelBase
    {
        public ObservableCollection<TaskTimerViewModel> TaskTimers { get; set; }

        private TaskTimerViewModel tempTimerViewModel;

        public TaskTimerViewModel TempTimerViewModel
        {
            get { return tempTimerViewModel; }
            set { tempTimerViewModel = value;
                OnPropertyChanged("TempTimerViewModel");
            }
        }


        public TaskTimerListViewModel()
        {
            this.TaskTimers = new ObservableCollection<TaskTimerViewModel>();

            //TODO REMOVE DEBUG CODE
            this.AddTaskTimer();
            this.AddTaskTimer();
            this.AddTaskTimer();

            this.TempTimerViewModel = TaskTimers[0];
        }

        public void AddTaskTimer(int miliSeconds = 3000, string description = "Default Task Description")
        {
            if(this.TaskTimers != null)
            {
                this.TaskTimers.Add(new TaskTimerViewModel(miliSeconds, description));
            }
        }

    }
}
