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

        public TaskToCompleteListViewModel()
        {
            this.TaskToCompleteList = new ObservableCollection<TaskToCompleteViewModel>();
            this.newTaskDescription = Constants.DefaultTaskDescription;

            this.AddTaskCommand = new RelayCommand(AddTaskToComplete);
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
    }
}
