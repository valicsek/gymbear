using System;
using gymbear.Models;

namespace gymbear.ViewModels.Interfaces
{
    public interface IAddExercise
    {
        /// <summary>
        /// Adds the exercise to database.
        /// </summary>
        /// <param name="exercise">Exercise.</param>
        void AddExerciseToDatabase(Exercise exercise);
    }
}
