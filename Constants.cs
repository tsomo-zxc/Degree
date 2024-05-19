using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree
{
    public static class OrderStatus
    {
        public static readonly string Pending = "Pending";
        public static readonly string InProgress = "In Progress";
        public static readonly string Completed = "Completed";
        public static readonly string Cancelled = "Cancelled";
    }
    
    public static class Constants
    {
        public const string DbName = "SQLite.db3";
        public const SQLiteOpenFlags DbFlags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DbPath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DbName);
            }
        }
    }
}
