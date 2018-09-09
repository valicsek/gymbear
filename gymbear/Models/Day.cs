using System;
namespace gymbear.Models
{
    public class Day
    {
        public Workout Workout { get; set; }

        public Day()
        {
            this.Workout = null;
        }
    }
}
