using System;
using System.Collections.ObjectModel;
using SQLite;

namespace gymbear.Models
{
    public class Week
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Workout[] Workout { get; set; }

        public Week()
        {
            this.Workout = new Workout[6];

            for (int i = 0; i < 6; i++)
            {
                this.Workout[i] = new Workout
                {
                    Exercises = new ObservableCollection<Exercise>()
                };
            }
        }
    }
}
