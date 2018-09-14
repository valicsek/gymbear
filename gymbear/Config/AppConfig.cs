using System;
using System.IO;
using gymbear.Models;

namespace gymbear.Config
{
    public abstract class AppConfig
    {
        // Default BreakTime
        public static int DefaultBreakTimeLeft = 60;
        static string dbName = "gymbear.sqlite";
        static string _folderpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
        public static string databasePath = Path.Combine(_folderpath, dbName);
        public static string serializeDatafilePath = Path.Combine(_folderpath, "data.xml");
        //
        // It returns the current index of the day
        // Sunday is 0, monday is 1 and so on
        // Further information:
        // https://stackoverflow.com/questions/9199080/how-to-get-the-integer-value-of-day-of-week
        public static int CurrentWorkout
        {
            get
            {
                return (int)DateTime.Now.DayOfWeek;
            }
        }
    }
}
