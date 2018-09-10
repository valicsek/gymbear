using System;
using gymbear.Models;
using gymbear.Services;

namespace gymbear.ViewModels
{
    public class WorkoutModelView : ViewModel
    {
        public Workout SelectedWorkout { get; set; }

        public Workout Workout { get; set; }

        public string Day {
            get {
                return DateTime.Now.ToString("dddd");
            }
        }

        public WorkoutModelView()
        {
            this.SelectedWorkout = null;
            this.Workout = Service.GetWorkoutByDay(0);
        }
    }
}
