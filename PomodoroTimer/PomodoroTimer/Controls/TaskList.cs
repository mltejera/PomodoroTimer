using PomodoroTimerLogic.ViewModels;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace PomodoroTimer
{
    public sealed class TaskList : Control
    {
        public TaskToCompleteListViewModel viewModel = new TaskToCompleteListViewModel(true);

        public TaskList()
        {
            this.DefaultStyleKey = typeof(TaskList);
            this.DataContext = viewModel;
        }
    }
}
