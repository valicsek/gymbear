using System;
using gymbear.Config;

namespace gymbear.ViewModels
{
    public class WorkoutOnGameViewModel: ViewModel
    {
        private int breakTimeLeft;
        public int BreakTimeLeft
        {
            get => breakTimeLeft;
            set => SetField<int>(ref breakTimeLeft, value);
        }

        public WorkoutOnGameViewModel()
        {
            this.BreakTimeLeft = AppConfig.DefaultBreakTimeLeft;
        }
    }
}
