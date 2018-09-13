using System;
using gymbear.Models;
using gymbear.Services;
using gymbear.ViewModels.Interfaces;

namespace gymbear.ViewModels
{
    public class AddExerciseViewModel : ViewModel, IAddExercise
    {

        public Array ExerciseTypes { get => Enum.GetValues(typeof(ExerciseType)); }

        private Exercise exercise;
        public Exercise Exercise
        {
            get => exercise;
            set => SetField<Exercise>(ref exercise, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:gymbear.ViewModels.AddExerciseViewModel"/> class.
        /// </summary>
        public AddExerciseViewModel()
        {
            this.exercise = new Exercise();
        }

        /// <summary>
        /// Adds the exercise to database.
        /// </summary>
        /// <param name="exercise">Exercise.</param>
        public void AddExerciseToDatabase(Exercise exercise)
        {
            if (string.IsNullOrEmpty(exercise.Name))
            {
                throw new Exception("The Exercise name is missing");
            }

            DatabaseService<Exercise>.Insert(exercise);
        }

    }
}