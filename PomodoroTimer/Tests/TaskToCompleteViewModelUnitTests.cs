
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskToCompleteViewModelUnitTests
    {
        [TestMethod]
        public void TestTaskToCompleteViewModelInit()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            Assert.AreEqual(viewModel.TaskName, "New Task");
            Assert.AreEqual(viewModel.IsComplete, false);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelChangeName()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.TaskName = "another name";

            Assert.AreEqual(viewModel.TaskName, "another name");
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelCompleteTask()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.IsComplete = true;
            
            Assert.AreEqual(viewModel.IsComplete, true);
        }
    }
}
