using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

namespace gymbear.Models
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public ObservableCollection<Exercise> Exercises { get; set; }

        public Workout()
        {
            this.Exercises = new ObservableCollection<Exercise>();
        }
    }
}
