﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerLogic.Models
{
    public class TaskTimer
    {
        public string Description { get; set; }

        public int TotalMiliseconds { get; set; }

        public int RemainingMiliseconds { get; set; }

        public bool IsRunning { get; set; }

        public bool IsComplete { get; set; }
    }
}