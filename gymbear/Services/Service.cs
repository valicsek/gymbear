using System;
using System.Collections.ObjectModel;
using gymbear.Models;

namespace gymbear.Services
{
    public abstract class Service
    {
        public static Workout GetWorkoutByDay(int dayIndex)
        {
            Week week = new Week();
            week.Workout[dayIndex] = new Workout
            {
                Exercises = new ObservableCollection<Exercise>
            {
                new Exercise() { Name = "Kalapács vetés" },
                new Exercise() { Name = "Kalapács vetés1" },
                new Exercise() { Name = "Kalapács vetés2" },
                new Exercise() { Name = "Kalapács vetés3" },
                new Exercise() { Name = "Kalapács vetés4" }
            }
            };
            return week.Workout[dayIndex];
        }
    }
}
