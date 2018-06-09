using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskTimerViewModelTests
    {
        const string defaultTaskDescription = "Default Task Description";

        [TestMethod]
        public void TestTaskTimerViewModelInit()
        {
            TaskTimerViewModel viewModel = new TaskTimerViewModel();

            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.AreEqual(viewModel.TaskTimerModel.IsComplete, false);
            Assert.AreEqual(viewModel.TaskTimerModel.IsRunning, false);
            Assert.AreEqual(viewModel.TaskTimerModel.TotalMiliseconds, 0);
            Assert.AreEqual(viewModel.TaskTimerModel.RemainingMiliseconds, 0);
        }

        [TestMethod]
        public void TestTaskTimerViewModelInitWithParams()
        {
            int totalMiliseconds = 3000;

            TaskTimerViewModel viewModel = new TaskTimerViewModel(totalMiliseconds);

            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.AreEqual(viewModel.TaskTimerModel.IsComplete, false);
            Assert.AreEqual(viewModel.TaskTimerModel.IsRunning, false);
            Assert.AreEqual(viewModel.TaskTimerModel.TotalMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.RemainingMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.Description, defaultTaskDescription);
        }

        [TestMethod]
        public void TestTaskTimerViewModelInitWithMiliseconds()
        {
            int totalMiliseconds = 3000;

            TaskTimerViewModel viewModel = new TaskTimerViewModel(totalMiliseconds);

            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.AreEqual(viewModel.TaskTimerModel.IsComplete, false);
            Assert.AreEqual(viewModel.TaskTimerModel.IsRunning, false);
            Assert.AreEqual(viewModel.TaskTimerModel.TotalMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.RemainingMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.Description, defaultTaskDescription);
        }

        [TestMethod]
        public void TestTaskTimerViewModelInitWithMilisecondsandDescription()
        {
            int totalMiliseconds = 3000;
            string newTaskDescription = "Something Other Than The Default Task Description";

            TaskTimerViewModel viewModel = new TaskTimerViewModel(totalMiliseconds, newTaskDescription);

            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.AreEqual(viewModel.TaskTimerModel.IsComplete, false);
            Assert.AreEqual(viewModel.TaskTimerModel.IsRunning, false);
            Assert.AreEqual(viewModel.TaskTimerModel.TotalMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.RemainingMiliseconds, totalMiliseconds);
            Assert.AreEqual(viewModel.TaskTimerModel.Description, newTaskDescription);
        }

    }
}
