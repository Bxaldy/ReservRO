using ReservRO.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ReservRO.Helper
{
  public static  class Utils
    {
        public static UserModel LogInUser { get; set; }
        public static SQLiteAsyncConnection db;
        public static async Task<SQLiteAsyncConnection> Init()
        {
            try
            {
                if (db != null)
                    return db;
                // Get an absolute path to the database file
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Infinity.db");

                db = new SQLiteAsyncConnection(databasePath);
                if (!Utils.TableExists("UserModel", db))
                    await db.CreateTableAsync<UserModel>();
                if (!Utils.TableExists("AppointmentsModel", db))
                    await db.CreateTableAsync<AppointmentsModel>();
                return db;
            }
            catch (Exception ex)
            {
               
            }
            return null;
        }
        public static bool TableExists(string tableName, SQLiteAsyncConnection connection)
        {
            try
            {
                var tableInfo = connection.GetConnection().GetTableInfo(tableName);
                if (tableInfo.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) {  return false; }
        }
    }
}
