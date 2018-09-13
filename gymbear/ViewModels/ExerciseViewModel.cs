using System;
using System.Collections.ObjectModel;
using System.Linq;
using gymbear.Models;

namespace gymbear.ViewModels
{
    public class ExerciseViewModel : ViewModel
    {
        public Array ExerciseTypes { get => Enum.GetValues(typeof(ExerciseType)); }

        ObservableCollection<Exercise> exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get => exercises;
            set => SetField<ObservableCollection<Exercise>>(ref exercises, value);
        }

        public ExerciseViewModel()
        {
            this.Exercises = null; // Services.Service.GetWorkoutByDay(Config.AppConfig.CurrentWorkout).Exercises;
        }

        /// <summary>
        /// Filters the exercise list.
        /// </summary>
        /// <param name="filterName">Filter name.</param>
        public void FilterExercise(string filterName)
        {
            if (string.IsNullOrEmpty(filterName))
            {
                this.Exercises = Services.Service.GetExercises();
                return;
            }
            this.Exercises = new ObservableCollection<Exercise>(Exercises.Where((obj) => obj.Name.ToLower().Contains(filterName.ToLower())).ToList());
        }
    }
}