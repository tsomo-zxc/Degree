using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree
{
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
