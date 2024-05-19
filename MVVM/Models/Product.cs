using Degree.MVVM.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Models
{
    [SQLite.Table("Products")]
    public class Product : TableData    
    {
        [MaxLength(100), NotNull,Unique]
        public string Name { get; set; }

        [NotNull]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        

    }
}
