using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Services
{
    public class SQLiteCloudService
    {
        private static SQLiteCloudService _instance;
        private SQLiteConnection _connection;

        private SQLiteCloudService(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public static SQLiteCloudService Instance
        {
            get
            {
                if (_instance == null)
                {
                    string connectionString =Path.Combine("sqlitecloud://ckl2dlopsk.sqlite.cloud:8860?apikey=13oDuQVJrfvS5SQHmfteLzI6JExANwiKQJux3NAEGAo","SQLite.db3");
                    _instance = new SQLiteCloudService(connectionString);
                }

                return _instance;
            }
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }
    }
}
