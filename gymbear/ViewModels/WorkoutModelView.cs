using System;
using System.Collections.ObjectModel;
using gymbear.Models;
using gymbear.Services;
using Xamarin.Forms;

namespace gymbear.ViewModels
{
    public class WorkoutModelView : ViewModel
    {

        public int CurrentWorkoutIndex { get; set; }

        /// <summary>
        /// The no exercise has been added.
        /// Further Information:
        /// https://forums.xamarin.com/discussion/43703/empty-label-when-listview-is-empty
        /// </summary>
        private bool noExerciseHasBeenAdded;
        public bool NoExerciseHasBeenAdded
        {
            get => noExerciseHasBeenAdded;
            set => SetField<bool>(ref noExerciseHasBeenAdded, value);
        }

        private Workout selectedWorkout;
        public Workout SelectedWorkout
        {
            get => selectedWorkout;
            set => SetField<Workout>(ref selectedWorkout, value);
        }

        private Workout workout;
        public Workout Workout
        {
            get => workout;
            set => SetField<Workout>(ref workout, value);
        }

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

        public string Day
        {
            get
            {
                return DateTime.Now.ToString("dddd");
            }
        }

        public WorkoutModelView()
        {
            this.SelectedWorkout = null;
            this.CurrentWorkoutIndex = Config.AppConfig.CurrentWorkout;
            this.Workout = Service.GetWorkoutByDay(this.CurrentWorkoutIndex);
            this.noExerciseHasBeenAdded = this.Workout.Exercises.Count == 0;


            if (Application.Current.Properties.ContainsKey("BreakTime"))
                this.BreakTime = (int)Application.Current.Properties["BreakTime"];
            if (Application.Current.Properties.ContainsKey("NuOfSets"))
                this.NuOfSets = (int)Application.Current.Properties["NuOfSets"];
            if (Application.Current.Properties.ContainsKey("NuOfRepetitions"))
                this.NuOfRepetitions = (int)Application.Current.Properties["NuOfRepetitions"];
        }
    }
}
