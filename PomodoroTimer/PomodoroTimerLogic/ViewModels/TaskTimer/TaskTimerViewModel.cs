using PomodoroTimerLogic.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace PomodoroTimerLogic.ViewModels
{
    public class TaskTimerViewModel : ViewModelBase
    {
        DispatcherTimer dispatcherTimer;

        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;

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

        public string TimeRemaining
        {
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
                this.ToggleTimer();
                this.TaskTimerModel.IsRunning = value;
                OnPropertyChanged("IsRunning");
            }
        }

        public bool IsComplete
        {
            get
            {
                return this.TaskTimerModel.IsComplete;
            }
            set
            {
                this.TaskTimerModel.IsComplete = value;
                OnPropertyChanged("IsComplete");
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

        public RelayCommand ResetTimeCommand
        {
            get;
            private set;
        }

        public TaskTimerViewModel()
        {
            this.initTaskTimerModel();
            this.initCommands();
            this.initTimer();
        }

        public TaskTimerViewModel(int totalMiliseconds = Constants.DefaultStartingTimeInMiliseconds, string description = Constants.DefaultTimerDescription)
        {
            this.initTaskTimerModel(totalMiliseconds, description);
            this.initCommands();
            this.initTimer();
        }

        private void initCommands()
        {
            this.AddMinuteCommand = new RelayCommand(this.AddMinute);
            this.RemoveMinuteCommand = new RelayCommand(this.RemoveMinute);
            this.ResetTimeCommand = new RelayCommand(this.ResetTimer);
        }

        private void initTaskTimerModel(int totalMiliseconds = Constants.DefaultStartingTimeInMiliseconds, string description = Constants.DefaultTimerDescription)
        {
            taskTimerModel = new TaskTimer();
            taskTimerModel.IsComplete = false;
            taskTimerModel.IsRunning = false;
            taskTimerModel.RemainingMiliseconds = totalMiliseconds;
            taskTimerModel.TotalMiliseconds = totalMiliseconds;
            taskTimerModel.Description = description;
        }

        private void initTimer()
        {
            this.dispatcherTimer = new DispatcherTimer();

            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            this.dispatcherTimer.Tick += DispatcherTimer_Tick;

            TimeSpan tickLength = TimeSpan.FromMilliseconds(Constants.ASecondInMiliseconds);

            this.cancellationTokenSource = new CancellationTokenSource();
        }

        public void AddMinute()
        {
            this.TaskTimerModel.RemainingMiliseconds += Constants.AMinuteInMiliSeconds;
            this.TaskTimerModel.TotalMiliseconds += Constants.AMinuteInMiliSeconds;
            this.IsComplete = false;

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
            if (this.IsRunning)
            {
                this.stopTimerTask();
            }
            else
            {
                this.startTimerTask();
            }
        }

        private void handleTimerCompletion()
        {
            this.cancellationTokenSource.Cancel();
            this.taskTimerModel.IsRunning = false;
            OnPropertyChanged("IsRunning");
            this.IsComplete = true;
        }

        public void startTimerTask()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = this.cancellationTokenSource.Token;
            this.startTimerTaskAsync();
        }

        //  For the simpler way to run a timer, see the comments and functions below.

        private async Task<bool> startTimerTaskAsync()
        {
            // Get off the UI thread.
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested && this.taskTimerModel.RemainingMiliseconds > 0)
                {   
                    //someOtherAsyncronousFunctionThatDoesWorkOffUIThread();

                    await Task.Delay(Constants.ASecondInMiliseconds, cancellationToken);

                    this.taskTimerModel.RemainingMiliseconds -= Constants.ASecondInMiliseconds;

                    // jump back to the UI thread so we can update the string
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        this.OnPropertyChanged("TimeRemaining");
                    });
                }

                // The timer ran out
                if (this.TaskTimerModel.RemainingMiliseconds <= 0)
                {
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        this.handleTimerCompletion();
                    });
                }

                this.taskTimerModel.IsRunning = false;
                OnPropertyChanged("IsRunning");
            });

            return this.taskTimerModel.IsComplete;
        }

        private void stopTimerTask()
        {
            this.cancellationTokenSource.Cancel();
            // We need a fresh token to restart the next timer
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        public void ResetTimer()
        {
            this.TaskTimerModel.IsRunning = false;
            this.IsComplete = false;
            this.taskTimerModel.RemainingMiliseconds = this.taskTimerModel.TotalMiliseconds;
            this.cancellationTokenSource.Cancel();

            OnPropertyChanged("IsRunning");
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
        
        //  The methods below are a to run a timer with C#'s built in DispatchTimer.
        //  Personally, I think it's the best way to build a simple stop watch where
        //  No work (other than updating the UI) is being done during the ticks.
        //  HOWEVER, this will run completely on the UI thread, and the instructions specified
        //  they're looking for competence in asynchronous programming, which this doesn't really demonstrate.
        //  So these are depricated in favor of the methods above.

        private void startTimer()
        {
            this.IsRunning = true;
            this.dispatcherTimer.Start();
        }

        private void stopTimer()
        {
            this.dispatcherTimer.Stop();
            this.IsRunning = false;
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            this.taskTimerModel.RemainingMiliseconds -= Constants.ASecondInMiliseconds;
            this.OnPropertyChanged("TimeRemaining");

            if (this.TaskTimerModel.RemainingMiliseconds <= 0)
            {
                this.stopTimer();
                this.taskTimerModel.IsComplete = true;
            }
        }

    }
}
