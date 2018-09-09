using System;
using gymbear.Config;

namespace gymbear.ViewModels
{
    public class WorkoutOnGameViewModel
    {
        public int BreakTimeLeft { get; set; }

        public WorkoutOnGameViewModel()
        {
            this.BreakTimeLeft = AppConfig.DefaultBreakTimeLeft;
        }
    }
}
