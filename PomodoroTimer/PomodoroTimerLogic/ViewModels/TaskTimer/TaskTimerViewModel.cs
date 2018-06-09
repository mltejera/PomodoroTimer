using PomodoroTimerLogic.Models;
using System;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerViewModel : ViewModelBase
    {
        private TaskTimer taskTimerModel;

        public TaskTimer TaskTimerModel
        {
            get { return taskTimerModel; }
            set { taskTimerModel = value; }
        }

        public string TimerDescription
        {
            get { return this.taskTimerModel.Description; }
            set
            {
                this.taskTimerModel.Description = value;
                OnPropertyChanged("TimerDescription");
            }
        }

        //TODO Remove when converting to use real time
        private string tempString { get; set; }

        public string TimeRemaining
        {
            // TODO: Convert this to a human readable string
            get { return this.ConvertMilisecondsToHumanTime(this.taskTimerModel.RemainingMiliseconds); }
        }

        public bool IsRunning
        {
            get
            {
                return this.TaskTimerModel.IsRunning;
            }
            set
            {
                this.TaskTimerModel.IsRunning = value;
                OnPropertyChanged("IsRunning");
            }
        }


        public RelayCommand AddMinuteCommand
        {
            get;
            private set;
        }

        public RelayCommand RemoveMinuteCommand
        {
            get;
            private set;
        }

        public RelayCommand ToggleStartStopCommand
        {
            get;
            private set;
        }

        public RelayCommand ResetTimeCommand
        {
            get;
            private set;
        }


        public TaskTimerViewModel()
        {
            this.initTaskTimerModel();
            this.initCommands();
        }

        public TaskTimerViewModel(int totalMiliseconds = 0)
        {
            this.initTaskTimerModel(totalMiliseconds);
            this.initCommands();
        }

        public TaskTimerViewModel(int totalMiliseconds, string description = Constants.DefaultTimerDescription)
        {
            this.initTaskTimerModel(totalMiliseconds, description);
            this.initCommands();
        }

        private void initCommands()
        {
            this.AddMinuteCommand = new RelayCommand(this.AddMinute);
            this.RemoveMinuteCommand = new RelayCommand(this.RemoveMinute);
            this.ToggleStartStopCommand = new RelayCommand(this.ToggleTimer);
            this.ResetTimeCommand = new RelayCommand(this.ResetTimer);
        }

        private void initTaskTimerModel(int totalMiliseconds = 0,string description = Constants.DefaultTimerDescription)
        {
            taskTimerModel = new TaskTimer();
            taskTimerModel.IsComplete = false;
            taskTimerModel.IsRunning = false;
            taskTimerModel.RemainingMiliseconds = totalMiliseconds;
            taskTimerModel.TotalMiliseconds = totalMiliseconds;
            taskTimerModel.Description = description;
        }

        public void AddMinute()
        {
            this.TaskTimerModel.RemainingMiliseconds += Constants.AMinuteInMiliSeconds;
            this.TaskTimerModel.TotalMiliseconds += Constants.AMinuteInMiliSeconds;

            OnPropertyChanged("TimeRemaining");
        }

        public void RemoveMinute()
        {
            if(this.TaskTimerModel.RemainingMiliseconds > Constants.AMinuteInMiliSeconds && this.TaskTimerModel.TotalMiliseconds > Constants.AMinuteInMiliSeconds)
            {
                this.TaskTimerModel.RemainingMiliseconds -= Constants.AMinuteInMiliSeconds;
                this.TaskTimerModel.TotalMiliseconds -= Constants.AMinuteInMiliSeconds;
            }
            else
            {
                this.TaskTimerModel.RemainingMiliseconds = 0;
                this.TaskTimerModel.TotalMiliseconds = 0;
            }

            OnPropertyChanged("TimeRemaining");
        }

        public void ToggleTimer()
        {
            this.IsRunning = this.taskTimerModel.IsRunning;
        }

        public void ResetTimer()
        {
            this.IsRunning = false;
            this.taskTimerModel.IsComplete = false;
            this.taskTimerModel.RemainingMiliseconds = this.taskTimerModel.TotalMiliseconds;

            OnPropertyChanged("TimeRemaining");
        }

        public string ConvertMilisecondsToHumanTime(int miliseconds)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(miliseconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
        }



        // TODO ALERTING

    }
}
