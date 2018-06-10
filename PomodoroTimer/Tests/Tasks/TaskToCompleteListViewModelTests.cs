using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskToCompleteListViewModelTests
    {
        [TestMethod]
        public void TestTaskToCompleteViewModelInit()
        {
            TaskToCompleteListViewModel viewModel = new TaskToCompleteListViewModel();

            Assert.IsNotNull(viewModel.TaskToCompleteList);

            Assert.AreEqual(viewModel.NewTaskDescription, Constants.DefaultTaskDescription);

            Assert.IsNotNull(viewModel.AddTaskCommand);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelChangeNewTaskDescription()
        {
            TaskToCompleteListViewModel viewModel = new TaskToCompleteListViewModel();
            string newTaskDescription = "hey I've been changed";

            viewModel.NewTaskDescription = newTaskDescription;

            Assert.AreEqual(viewModel.NewTaskDescription, newTaskDescription);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelAddTaskToComplete()
        {
            TaskToCompleteListViewModel viewModel = new TaskToCompleteListViewModel();
            string newTaskDescription = "hey I've been changed";
            viewModel.NewTaskDescription = newTaskDescription;

            viewModel.AddTaskToComplete();

            Assert.AreEqual(viewModel.TaskToCompleteList.Count, 1);
            Assert.AreEqual(viewModel.TaskToCompleteList[0].TaskDescription, newTaskDescription);
            Assert.AreEqual(viewModel.NewTaskDescription, Constants.DefaultTaskDescription);
        }

        [TestMethod]
        public void TestTaskToCompleteViewModelAddThreeTasks()
        {
            TaskToCompleteListViewModel viewModel = new TaskToCompleteListViewModel();

            viewModel.AddTaskToComplete();
            viewModel.AddTaskToComplete();
            viewModel.AddTaskToComplete();

            Assert.AreEqual(viewModel.TaskToCompleteList.Count, 3);
        }
    }
}