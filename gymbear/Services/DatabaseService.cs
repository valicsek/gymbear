using System;
using System.Collections.ObjectModel;
using System.Linq;
using gymbear.Models;
using SQLite;

namespace gymbear.Services
{
    public static class DatabaseService<T>
    {

        public static void Insert(T item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Config.AppConfig.databasePath))
            {
                connection.CreateTable<Exercise>();
                connection.Insert(item);
            }
        }

        public static void Update(T item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Config.AppConfig.databasePath))
            {
                connection.CreateTable<Exercise>();
                connection.Update(item);
            }
        }

        public static void Delete(T item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(Config.AppConfig.databasePath))
            {
                connection.CreateTable<Exercise>();
                connection.Delete(item);
            }
        }
    }
}
