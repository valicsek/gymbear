using System;
using System.Collections.ObjectModel;
using gymbear.Models;
using System.Linq;

namespace gymbear.ViewModels
{
    public class AddExerciseToWorkoutViewModel : ViewModel
    {
        public Array ExerciseTypes { get => Enum.GetValues(typeof(ExerciseType)); }

        private ObservableCollection<Exercise> exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get => exercises;
            set => SetField<ObservableCollection<Exercise>>(ref exercises, value);
        }

        private Exercise exercise;
        public Exercise Exercise

        {
            get => exercise;
            set => SetField<Exercise>(ref exercise, value);
        }

        public AddExerciseToWorkoutViewModel()
        {
            this.Exercise = new Exercise();
            this.Exercises = Services.Service.GetExercises();
        }

        /// <summary>
        /// Filters the exercise list
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
