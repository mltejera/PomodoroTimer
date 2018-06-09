using System.Collections.ObjectModel;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerListViewModel : ViewModelBase
    {
        const string defaultTimerDescription = "Default Timer Description";

        public ObservableCollection<TaskTimerViewModel> TaskTimers { get; set; }

        public RelayCommand AddTimerCommand
        {
            get;
            private set;
        }

        private string newTimerDescription;

        public string NewTimerDescription
        {
            get { return newTimerDescription; }
            set
            {
                newTimerDescription = value;
                this.OnPropertyChanged("newTimerDescription");
            }
        }

        public TaskTimerListViewModel()
        {
            this.TaskTimers = new ObservableCollection<TaskTimerViewModel>();

            this.AddTimerCommand = new RelayCommand(AddTaskTimer);

            this.NewTimerDescription = defaultTimerDescription;


            //TODO REMOVE DEBUG CODE
            this.AddTaskTimer();
            this.AddTaskTimer();
            this.AddTaskTimer();
        }

        public void AddTaskTimer()
        {
            if(this.TaskTimers != null && !string.IsNullOrWhiteSpace(this.newTimerDescription))
            {
                this.TaskTimers.Add(new TaskTimerViewModel(15000, newTimerDescription));

                this.NewTimerDescription = defaultTimerDescription;
            }
        }

    }
}
