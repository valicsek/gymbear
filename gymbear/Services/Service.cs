using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using gymbear.Helpers;
using gymbear.Models;
using SQLite;
using Xamarin.Forms;

namespace gymbear.Services
{
    public abstract class Service
    {
        public static Week Week { get; set; }

        /// <summary>
        /// Initializes the week.
        /// ERROR: if you add complex ObservableCollection, not save properties.
        /// </summary>
        public static void InitializeWeek()
        {
            try
            {
                Week = Serializer.DeSerializeObject<Week>(Config.AppConfig.serializeDatafilePath);
            }
            catch (Exception ex)
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

                Week = week;
            }
        }

        /// <summary>
        /// Gets the workout by day.
        /// </summary>
        /// <returns>The workout by day.</returns>
        /// <param name="dayIndex">Day index.</param>
        public static Workout GetWorkoutByDay(int dayIndex)
        {
            return Week.Workout[dayIndex];
        }

        /// <summary>
        /// Gets the exercises.
        /// </summary>
        /// <returns>The exercises.</returns>
        public static ObservableCollection<Exercise> GetExercises()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Config.AppConfig.databasePath))
            {
                connection.CreateTable<Exercise>();
                return new ObservableCollection<Exercise>(connection.Table<Exercise>().ToList());
            }
        }

        /// <summary>
        /// Gets the week.
        /// </summary>
        /// <returns>The week.</returns>
        public static Week GetWeek()
        {
            return Week;
        }

        /// <summary>
        /// Uploads the week.
        /// </summary>
        /// <param name="week">Week.</param>
        public static void UploadWeek(Week week)
        {
            Week = week;
            Serializer.SerializeObject<Week>(Week, Config.AppConfig.serializeDatafilePath);
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
            app.Properties[key] = obj;
            app.SavePropertiesAsync();
        }
    }
}
