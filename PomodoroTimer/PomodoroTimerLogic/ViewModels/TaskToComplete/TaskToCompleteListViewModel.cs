using System;
using System.Collections.ObjectModel;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskToCompleteListViewModel : ViewModelBase
    {

        public ObservableCollection<TaskToCompleteViewModel> TaskToCompleteList { get; set; }

        public RelayCommand AddTaskCommand
        {
            get;
            private set;
        }

        private string newTaskDescription;

        public string NewTaskDescription
        {
            get { return newTaskDescription; }
            set
            {
                newTaskDescription = value;
                this.OnPropertyChanged("NewTaskDescription");
            }
        }

        public TaskToCompleteListViewModel(bool prePopulate = false)
        {
            this.TaskToCompleteList = new ObservableCollection<TaskToCompleteViewModel>();
            this.newTaskDescription = Constants.DefaultTaskDescription;

            this.AddTaskCommand = new RelayCommand(AddTaskToComplete);

            if (prePopulate)
            {
                this.prePopulate();
            }
        }

        public void AddTaskToComplete()
        {
            if(this.TaskToCompleteList != null && !string.IsNullOrWhiteSpace(this.newTaskDescription))
            { 
                TaskToCompleteViewModel taskToComplete = new TaskToCompleteViewModel(this.newTaskDescription);
            
                TaskToCompleteList.Add(taskToComplete);

                this.NewTaskDescription = Constants.DefaultTaskDescription;
            }      
        }

        public void AddTaskToComplete(string description)
        {
            if (this.TaskToCompleteList != null)
            {
                TaskToCompleteViewModel taskToComplete = new TaskToCompleteViewModel(description);

                TaskToCompleteList.Add(taskToComplete);
            }
        }

        private void prePopulate()
        {
            this.AddTaskToComplete("Design UI");
            this.AddTaskToComplete("Sync with Brian");
            this.AddTaskToComplete("Make Dr. appointment");
            this.AddTaskToComplete("Report Hours");
        }
    }
}
