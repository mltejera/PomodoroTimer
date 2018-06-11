using PomodoroTimerLogic.ViewModels;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace PomodoroTimer
{
    public sealed class TaskTimerList : Control
    {
        public TaskTimerListViewModel viewModel = new TaskTimerListViewModel(true);

        public TaskTimerList()
        {
            this.DefaultStyleKey = typeof(TaskTimerList);
            this.DataContext = viewModel;
        }
    }
}
