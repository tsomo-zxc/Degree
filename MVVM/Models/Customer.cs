using Degree.MVVM.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Models
{
    [SQLite.Table("Customers")]
    public class Customer : TableData
    {
        //[PrimaryKey, AutoIncrement]
        //public int ID { get; set; }
        [SQLite.Column("name"), Indexed,NotNull]
        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
