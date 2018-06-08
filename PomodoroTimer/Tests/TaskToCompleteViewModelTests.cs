
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskToCompleteViewModelTests
    {
        [TestMethod]
        public void TestTaskToCompleteViewModelInit()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            Assert.AreEqual(viewModel.TaskDescription, "New Task");
            Assert.AreEqual(viewModel.IsComplete, false);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelInitWithName()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel("A name");

            Assert.AreEqual(viewModel.TaskDescription, "A name");
            Assert.AreEqual(viewModel.IsComplete, false);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelChangeName()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.TaskDescription = "another name";

            Assert.AreEqual(viewModel.TaskDescription, "another name");
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelCompleteTask()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.IsComplete = true;
            
            Assert.AreEqual(viewModel.IsComplete, true);
        }


        [TestMethod]
        public void TestTaskToCompleteViewModelToggleCompletion()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.ToggleCompletion();

            Assert.AreEqual(viewModel.IsComplete, true);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelToggleConsecutiveCompletion()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.ToggleCompletion();

            Assert.AreEqual(viewModel.IsComplete, true);

            viewModel.ToggleCompletion();

            Assert.AreEqual(viewModel.IsComplete, false);
        }


        [TestMethod]
        public void TestTaskToCompleteViewModelToggleMultipleCompletion()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.ToggleCompletion();

            viewModel.ToggleCompletion();

            Assert.AreEqual(viewModel.IsComplete, false);
        }
    }
}
