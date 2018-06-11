using System.Collections.ObjectModel;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerListViewModel : ViewModelBase
    {
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

        public TaskTimerListViewModel(bool prePopulate = false)
        {
            this.TaskTimers = new ObservableCollection<TaskTimerViewModel>();

            this.AddTimerCommand = new RelayCommand(AddTaskTimer);

            this.NewTimerDescription = Constants.DefaultTimerDescription;

            if(prePopulate)
            {
                this.populateWithDefaults();
            }
        }

        public void AddTaskTimer()
        {
            if(this.TaskTimers != null && !string.IsNullOrWhiteSpace(this.newTimerDescription))
            {
                this.TaskTimers.Add(new TaskTimerViewModel(Constants.DefaultStartingTimeInMiliseconds, newTimerDescription));

                this.NewTimerDescription = Constants.DefaultTimerDescription;
            }
        }

        public void AddTaskTimer(string description, int miliseconds)
        {
            if (this.TaskTimers != null && !string.IsNullOrWhiteSpace(description) && miliseconds > 0)
            {
                this.TaskTimers.Add(new TaskTimerViewModel(miliseconds, description));
            }
        }

        private void populateWithDefaults()
        {
            this.AddTaskTimer("Review Spec", Constants.TwentyFiveMinutesInMiliSeconds);
            this.AddTaskTimer("Get Coffee", Constants.FiveMinutesInMiliSeconds);
            this.AddTaskTimer("Write Tests", Constants.TwentyFiveMinutesInMiliSeconds);
            this.AddTaskTimer("Get Snack", Constants.FiveMinutesInMiliSeconds);
            this.AddTaskTimer("Write Code", Constants.TwentyFiveMinutesInMiliSeconds);
            this.AddTaskTimer("Bio Break", Constants.FiveMinutesInMiliSeconds);
            this.AddTaskTimer("Fix Bugs", Constants.TwentyFiveMinutesInMiliSeconds);
            this.AddTaskTimer("Go To Lunch", Constants.ThirtyMinutesInMiliSeconds);
        }

    }
}
