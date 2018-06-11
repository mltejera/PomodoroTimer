using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskTimerListViewModelTests
    {
        [TestMethod]
        public void TestTaskTimerListViewModelInit()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            Assert.IsNotNull(viewModel.TaskTimers);
        }

        [TestMethod]
        public void TaskTimerListViewModelAddTask()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            viewModel.AddTaskTimer();

            Assert.AreEqual(viewModel.TaskTimers.Count, 1);
        }

        [TestMethod]
        public void TaskTimerListViewModelAddTaskWithParams()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            viewModel.AddTaskTimer(Constants.DefaultTimerDescription, Constants.FiveMinutesInMiliSeconds);

            Assert.AreEqual(viewModel.TaskTimers.Count, 1);
            Assert.AreEqual(viewModel.TaskTimers[0].TimerDescription, Constants.DefaultTimerDescription);
            Assert.AreEqual(viewModel.TaskTimers[0].TaskTimerModel.TotalMiliseconds, Constants.FiveMinutesInMiliSeconds);
        }

        [TestMethod]
        public void TaskTimerListViewModelAddTaskWithParamsSadDescription()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            viewModel.AddTaskTimer(" ", Constants.FiveMinutesInMiliSeconds);

            Assert.AreEqual(viewModel.TaskTimers.Count, 0);
        }

        [TestMethod]
        public void TaskTimerListViewModelAddTaskWithParamsSadTime()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            viewModel.AddTaskTimer(Constants.DefaultTimerDescription, -1);

            Assert.AreEqual(viewModel.TaskTimers.Count, 0);
        }

        [TestMethod]
        public void TaskTimerListViewModelAddTaskWithParamsAllSadParams()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel();

            viewModel.AddTaskTimer(null, -1);

            Assert.AreEqual(viewModel.TaskTimers.Count, 0);
        }

        [TestMethod]
        public void TaskTimerListViewModelPopulateWithDefaults()
        {
            TaskTimerListViewModel viewModel = new TaskTimerListViewModel(true);

            Assert.AreEqual(viewModel.TaskTimers.Count, 8);
        }
    }
}
