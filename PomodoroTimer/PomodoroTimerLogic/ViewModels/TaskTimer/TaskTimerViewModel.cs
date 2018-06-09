using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTimerLogic.Models;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerViewModel : ViewModelBase
    {
        const string defaultTaskDescription = "Default Task Description";

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
            // TODO: Convert to this.taskTimerModel.RemainingMiliseconds;
            get { return "12:30:50"; }
            set
            {
                tempString = value;
                OnPropertyChanged("TimeRemaining");
                //this.taskTimerModel.Description = value;
                //OnPropertyChanged("TimerDescription");
            }
        }


        public TaskTimerViewModel()
        {
            this.initTaskTimerModel();
        }

        public TaskTimerViewModel(int totalMiliseconds = 0)
        {
            this.initTaskTimerModel(totalMiliseconds);
        }

        public TaskTimerViewModel(int totalMiliseconds, string description = defaultTaskDescription)
        {
            this.initTaskTimerModel(totalMiliseconds, description);
        }

        private void initTaskTimerModel(int totalMiliseconds = 0,string description = defaultTaskDescription)
        {
            taskTimerModel = new TaskTimer();
            taskTimerModel.IsComplete = false;
            taskTimerModel.IsRunning = false;
            taskTimerModel.RemainingMiliseconds = totalMiliseconds;
            taskTimerModel.TotalMiliseconds = totalMiliseconds;
            taskTimerModel.Description = description;
        }

        // Start
        public void StartTimer()
        {

        }
        

        // Stop
        public void StopTimer()
        {

        }

        // Add minute

        // Subtract minute

        // Alerting system?

    }
}
