using System;
namespace gymbear.Models
{
    public class Week
    {
        public Workout[] Workout { get; set; }

        public Week()
        {
            this.Workout = new Workout[6];
        }
    }
}
