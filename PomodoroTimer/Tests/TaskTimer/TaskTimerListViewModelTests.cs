using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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




    }
}
