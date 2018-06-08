using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskToCompleteListViewModel
    {
        // TODO: Localize
        const string defaultNewTaskDescription = "A new task";

        public ObservableCollection<TaskToCompleteViewModel> TaskToCompleteList { get; set; }

        public TaskToCompleteListViewModel()
        {
            this.TaskToCompleteList = new ObservableCollection<TaskToCompleteViewModel>();
            this.newTaskDescription = defaultNewTaskDescription;
        }

        private string newTaskDescription;

        public string NewTaskDescription
        {
            get { return newTaskDescription; }
            set { newTaskDescription = value; }
        }


        public bool AddTaskToComplete()
        {
            bool success = false;

            if(this.TaskToCompleteList != null && !string.IsNullOrWhiteSpace(this.NewTaskDescription))
            { 
                TaskToCompleteViewModel taskToComplete = new TaskToCompleteViewModel(this.NewTaskDescription);
            
                TaskToCompleteList.Add(taskToComplete);

                this.NewTaskDescription = defaultNewTaskDescription;

                success = true;
            }

            return success;            
        }
    }
}
