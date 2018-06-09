using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskToCompleteListViewModel : ViewModelBase
    {
        // TODO: Localize
        const string defaultNewTaskDescription = "A new task";

        public ObservableCollection<TaskToCompleteViewModel> TaskToCompleteList { get; set; }

        public RelayCommand AddTaskCommand
        {
            get;
            private set;
        }

        public TaskToCompleteListViewModel()
        {
            this.TaskToCompleteList = new ObservableCollection<TaskToCompleteViewModel>();
            this.newTaskDescription = defaultNewTaskDescription;

            this.AddTaskCommand = new RelayCommand(AddTaskToComplete);

            // TODO DELETE DEBUG CODE
            // OR MAKE INTENTIONAL
            this.AddTaskToComplete();
            this.AddTaskToComplete();
            this.AddTaskToComplete();
            this.AddTaskToComplete();

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

        public void AddTaskToComplete()
        {
            if(this.TaskToCompleteList != null && !string.IsNullOrWhiteSpace(this.NewTaskDescription))
            { 
                TaskToCompleteViewModel taskToComplete = new TaskToCompleteViewModel(this.NewTaskDescription);
            
                TaskToCompleteList.Add(taskToComplete);

                this.NewTaskDescription = defaultNewTaskDescription;
            }      
        }
    }
}
