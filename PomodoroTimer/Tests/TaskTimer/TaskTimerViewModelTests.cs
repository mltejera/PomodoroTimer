﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class TaskTimerViewModelTests
    {
        [TestMethod]
        public void TestTaskTimerViewModelInit()
        {
            TaskTimerViewModel viewModel = new TaskTimerViewModel();

            Assert.IsNotNull(viewModel.TaskTimerModel);
            Assert.AreEqual(viewModel.TimerDescription, Constants.DefaultTimerDescription);
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
            Assert.AreEqual(viewModel.TimerDescription, Constants.DefaultTimerDescription);
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
            Assert.AreEqual(viewModel.TimerDescription, Constants.DefaultTimerDescription);
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

        [TestMethod]
        public void TestTaskTimerViewModelAddMinute()
        {
            TaskTimerViewModel timerVM = new TaskTimerViewModel();

            timerVM.AddMinute();

            Assert.AreEqual(timerVM.TaskTimerModel.RemainingMiliseconds, Constants.DefaultStartingTimeInMiliseconds + Constants.AMinuteInMiliSeconds);
            Assert.AreEqual(timerVM.TaskTimerModel.TotalMiliseconds, Constants.DefaultStartingTimeInMiliseconds + Constants.AMinuteInMiliSeconds);
        }

        [TestMethod]
        public void TestTaskTimerViewModelRemoveMinute()
        {
            TaskTimerViewModel timerVM = new TaskTimerViewModel();

            timerVM.RemoveMinute();

            Assert.AreEqual(timerVM.TaskTimerModel.RemainingMiliseconds, Constants.DefaultStartingTimeInMiliseconds - Constants.AMinuteInMiliSeconds);
            Assert.AreEqual(timerVM.TaskTimerModel.TotalMiliseconds, Constants.DefaultStartingTimeInMiliseconds - Constants.AMinuteInMiliSeconds);
        }

        [TestMethod]
        public void TestTaskTimerViewModelRemoveMinutePassedZero()
        {
            TaskTimerViewModel timerVM = new TaskTimerViewModel();

            // Remove at least 5 minutes
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();

            Assert.AreEqual(timerVM.TaskTimerModel.RemainingMiliseconds, 0);
            Assert.AreEqual(timerVM.TaskTimerModel.TotalMiliseconds, 0);
        }

        [TestMethod]
        public void TestTaskTimerViewModelResetTimer()
        {
            TaskTimerViewModel timerVM = new TaskTimerViewModel();

            // Remove 2 minutes
            timerVM.RemoveMinute();
            timerVM.RemoveMinute();

            timerVM.ResetTimer();

            Assert.AreEqual(timerVM.TaskTimerModel.RemainingMiliseconds, Constants.DefaultStartingTimeInMiliseconds);
            Assert.AreEqual(timerVM.TaskTimerModel.TotalMiliseconds, Constants.DefaultStartingTimeInMiliseconds);
        }



    }
}
