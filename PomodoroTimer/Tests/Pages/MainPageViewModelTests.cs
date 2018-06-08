using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLogic.ViewModels;

namespace Tests
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        public void TestMainPageViewModelInit()
        {
            MainPageViewModel viewModel = new MainPageViewModel();

            Assert.IsNotNull(viewModel.TaskToCompleteListViewModel);
        }
    }
}