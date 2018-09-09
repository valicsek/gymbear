using System;
using gymbear.Models;

namespace gymbear.ViewModel
{
    public class WorkoutModelView
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

            Exercise chest = new Exercise() { Name = "Push using chest", ExerciseType = ExerciseType.Chest };
            Exercise back = new Exercise() { Name = "Push using back", ExerciseType = ExerciseType.Back };
            Exercise ch2 = new Exercise() { Name = "Weight for chest", ExerciseType = ExerciseType.Chest };

            this.Workout = new Workout();
            this.Workout.Exercises.Add(chest);
            this.Workout.Exercises.Add(back);
            this.Workout.Exercises.Add(ch2);
        }
    }
}
