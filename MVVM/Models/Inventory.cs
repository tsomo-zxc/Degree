using Degree.MVVM.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Models
{
    [SQLite.Table("Inventory")]
    public class Inventory : TableData
    {
       
        [NotNull, SQLiteNetExtensions.Attributes.ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [NotNull, SQLiteNetExtensions.Attributes.ForeignKey(typeof(Product))]
        public int ProductId { get; set; }

        [NotNull]
        public int Quantity { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public User User { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Product Product { get; set; }

    }
}
