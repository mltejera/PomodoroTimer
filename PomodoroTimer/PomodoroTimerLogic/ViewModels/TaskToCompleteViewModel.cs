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

        public string TaskName
        {
            get { return this.TaskModel.TaskDescription; }
            set
            {
                this.TaskModel.TaskDescription  = value;
                this.OnPropertyChanged("TaskName");
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


    }
}
