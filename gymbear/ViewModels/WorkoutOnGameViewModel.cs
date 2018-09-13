using System;
using System.Collections.ObjectModel;
using gymbear.Config;
using gymbear.Models;
using gymbear.Services;
using Xamarin.Forms;

namespace gymbear.ViewModels
{
    public class WorkoutOnGameViewModel : ViewModel
    {
        private int indexOfCurrentExercise;

        private string timer;
        public string Timer
        {
            get => timer;
            set => SetField<string>(ref timer, value);
        }

        private int breakTimeLeft;
        public int BreakTimeLeft
        {
            get => breakTimeLeft;
            set => SetField<int>(ref breakTimeLeft, value);
        }

        private Exercise currentExercise;
        public Exercise CurrentExercise
        {
            get => currentExercise;
            set => SetField<Exercise>(ref currentExercise, value);
        }

        private Workout workout;
        public Workout Workout
        {
            get => workout;
            set => SetField<Workout>(ref workout, value);
        }

        int[] sets;
        public int[] Sets
        {
            get => sets;
            set => SetField<int[]>(ref sets, value);
        }

        public WorkoutOnGameViewModel()
        {
            this.BreakTimeLeft = (int)Application.Current.Properties["BreakTime"];
            this.indexOfCurrentExercise = 0;
            this.Timer = "Timer: 00:00:00";
            this.LoadWorkout();

            this.Sets = new int[(int)Application.Current.Properties["NuOfSets"]];
        }

        /// <summary>
        /// Loads the workout according to the current day (Monday,Tuesday ..)
        /// </summary>
        void LoadWorkout()
        {
            this.Workout = Service.GetWorkoutByDay(Config.AppConfig.CurrentWorkout);
            if (this.Workout.Exercises == null)
            {
                throw new Exception("No Exercise have been added yet.");
            }
            this.currentExercise = this.Workout.Exercises[this.indexOfCurrentExercise];
        }

        /// <summary>
        /// This function starts the timer which count how much time
        /// we spent with the whole workout.
        /// </summary>
        public void StartTimer()
        {
            TimeSpan _elapsed = new TimeSpan();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
                this.Timer = String.Format("Timer: {0}", _elapsed.ToString());
                return true;
            });
        }

        /// <summary>
        /// This function steps the next exercise until it reaches the last one.
        /// If there are no more exercises it returns false otherwise true;
        /// </summary>
        /// <returns><c>true</c>, if next exercise was shown, <c>false</c> otherwise.</returns>
        public bool ShowNextExercise()
        {
            this.Sets = new int[(int)Application.Current.Properties["NuOfSets"]];
            this.indexOfCurrentExercise++;
            if (this.indexOfCurrentExercise < this.Workout.Exercises.Count)
            {
                this.CurrentExercise = this.Workout.Exercises[this.indexOfCurrentExercise];
                return true;
            }
            return false;
        }
    }
}
