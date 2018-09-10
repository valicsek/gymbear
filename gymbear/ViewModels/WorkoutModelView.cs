using System;
using System.Collections.ObjectModel;
using gymbear.Models;
using gymbear.Services;
using Xamarin.Forms;

namespace gymbear.ViewModels
{
    public class WorkoutModelView : ViewModel
    {
        public Workout SelectedWorkout { get; set; }

        public Workout Workout { get; set; }

        private int breakTime;
        public int BreakTime
        {
            get => breakTime;
            set => SetField<int>(ref breakTime, value);
        }

        private int nuOfSets;
        public int NuOfSets
        {
            get => nuOfSets;
            set => SetField<int>(ref nuOfSets, value);
        }

        private int nuOfRepetitions;
        public int NuOfRepetitions
        {
            get => nuOfRepetitions;
            set => SetField<int>(ref nuOfRepetitions, value);
        }

        public string Day {
            get {
                return DateTime.Now.ToString("dddd");
            }
        }

        public WorkoutModelView()
        {
            this.SelectedWorkout = null;
            this.Workout = Service.GetWorkoutByDay(0);
 
            if (Application.Current.Properties.ContainsKey("BreakTime"))
                this.BreakTime = (int)Application.Current.Properties["BreakTime"];
            if (Application.Current.Properties.ContainsKey("NuOfSets"))
                this.NuOfSets = (int)Application.Current.Properties["NuOfSets"];
            if (Application.Current.Properties.ContainsKey("NuOfRepetitions"))
                this.NuOfRepetitions = (int)Application.Current.Properties["NuOfRepetitions"];
        }
    }
}
