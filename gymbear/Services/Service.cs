using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using gymbear.Models;
using SQLite;
using Xamarin.Forms;

namespace gymbear.Services
{
    public abstract class Service
    {
        /// <summary>
        /// Initializes the week.
        /// ERROR: if you add complex ObservableCollection, not save properties.
        /// </summary>
        public static void InitializeWeek()
        {
            if (!Application.Current.Properties.ContainsKey("Week"))
            {
                Week week = new Week
                {
                    Workout = new Workout[6]
                };

                for (int i = 0; i < 6; i++)
                {
                    week.Workout[i] = new Workout
                    {
                        Exercises = new ObservableCollection<Exercise>()
                    };
                }

                Application.Current.Properties["Week"] = week.ToString();
            }
        }

        /// <summary>
        /// Gets the workout by day.
        /// </summary>
        /// <returns>The workout by day.</returns>
        /// <param name="dayIndex">Day index.</param>
        public static Workout GetWorkoutByDay(int dayIndex)
        {
            return new Workout();
        }

        /// <summary>
        /// Gets the exercises.
        /// </summary>
        /// <returns>The exercises.</returns>
        public static ObservableCollection<Exercise> GetExercises()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Config.AppConfig.databasePath))
            {
                return new ObservableCollection<Exercise>(connection.Table<Exercise>().ToList());
            }
        }

        /// <summary>
        /// Gets the week.
        /// </summary>
        /// <returns>The week.</returns>
        public static Week GetWeek()
        {
            Week week = Application.Current.Properties["Week"] as Week;
            return week;
        }

        /// <summary>
        /// Uploads the week.
        /// </summary>
        /// <param name="week">Week.</param>
        public static void UploadWeek(Week week)
        {
            Application.Current.Properties["Week"] = week;
        }

        /// <summary>
        /// Saves the local config.
        /// https://forums.xamarin.com/discussion/41737/application-current-properties
        /// ERROR: if you add complex ObservableCollection, not will save the properties.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="obj">Object.</param>
        public static void SaveLocalConfig(string key, object obj)
        {
            var app = (App)Application.Current;
            app.Properties[key] = obj.ToString();
            app.SavePropertiesAsync();
        }
    }
}
