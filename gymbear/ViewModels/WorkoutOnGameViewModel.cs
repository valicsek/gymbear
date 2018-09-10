using System;
using gymbear.Config;
using gymbear.Models;
using Xamarin.Forms;

namespace gymbear.ViewModels
{
    public class WorkoutOnGameViewModel: ViewModel
    {
        private int indexOfCurrentExercise;
        private int elapsedSecond;

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
        public Workout Workout {
            get => workout;
            set => SetField<Workout>(ref workout, value);
        }

        public WorkoutOnGameViewModel()
        {
            this.BreakTimeLeft = AppConfig.DefaultBreakTimeLeft;
            this.elapsedSecond = 0;
            this.Timer = "00:00:00";
            this.LoadWorkout();
        }

        void LoadWorkout()
        {
            this.Workout = new Workout();
            this.Workout.Exercises.Add(new Exercise { Name = "Back push", ExerciseType = ExerciseType.Back });
            this.Workout.Exercises.Add(new Exercise { Name = "Chest push", ExerciseType = ExerciseType.Chest });

            this.indexOfCurrentExercise = 0;
            this.currentExercise = this.Workout.Exercises[this.indexOfCurrentExercise];
        }

        public void StartTimer()
        {
            TimeSpan _elapsed = new TimeSpan();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
                this.Timer = _elapsed.ToString();
                return true;
            });
        }

        //
        // This function steps the next exercise until it reaches the last one.
        // If there are no more exercises it returns false otherwise true;
        //
        public bool ShowNextExercise()
        {
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
