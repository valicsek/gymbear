using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gymbear.Models
{
    public class Workout
    {
        public ObservableCollection<Exercise> Exercises { get; set; }

        public Workout()
        {
            this.Exercises = new ObservableCollection<Exercise>();
        }
    }
}
