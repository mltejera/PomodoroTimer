using PomodoroTimerLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskToCompleteViewModel : ViewModelBase
    {
        public TaskToComplete TaskModel { get; set; }

        public string TaskDescription
        {
            get { return this.TaskModel.TaskDescription; }
            set
            {
                this.TaskModel.TaskDescription = value;
                this.OnPropertyChanged("TaskDescription");
            }
        }

        public bool IsComplete
        {
            get { return this.TaskModel.IsComplete; }
            set
            {
                this.TaskModel.IsComplete = value;
                this.OnPropertyChanged("IsComplete");
            }
        }
        
        public TaskToCompleteViewModel()
        {
            this.TaskModel = new TaskToComplete();
            this.TaskModel.TaskDescription = "New Task";
            this.TaskModel.IsComplete = false;
        }

        public TaskToCompleteViewModel(string taskDescription)
        {
            this.TaskModel = new TaskToComplete();
            this.TaskModel.TaskDescription = taskDescription;
            this.TaskModel.IsComplete = false;
        }

        public void ToggleCompletion()
        {
            this.IsComplete = !this.TaskModel.IsComplete;
        }

    }
}
