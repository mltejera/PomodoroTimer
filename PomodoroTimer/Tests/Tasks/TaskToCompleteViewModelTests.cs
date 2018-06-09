
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic.ViewModels;

using PomodoroTimerLogic;

namespace Tests
{
    [TestClass]
    public class TaskToCompleteViewModelTests
    {
        [TestMethod]
        public void TestTaskToCompleteViewModelInit()
        {
            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            Assert.AreEqual(viewModel.TaskDescription, Constants.DefaultTaskDescription);
            Assert.AreEqual(viewModel.IsComplete, false);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelInitWithName()
        {
            string testString = "a name";

            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel(testString);

            Assert.AreEqual(viewModel.TaskDescription, testString);
            Assert.AreEqual(viewModel.IsComplete, false);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelChangeName()
        {
            string testString = "another name";

            TaskToCompleteViewModel viewModel = new TaskToCompleteViewModel();

            viewModel.TaskDescription = testString;

            Assert.AreEqual(viewModel.TaskDescription, testString);
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
