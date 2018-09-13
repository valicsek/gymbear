using System;
using SQLite;
using Xamarin.Forms;

namespace gymbear.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public int nuOfSets { get; set; }

        public int nuOfRepetitions { get; set; }

        public Exercise()
        {
        }
    }
}
