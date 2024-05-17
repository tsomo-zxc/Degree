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
    [SQLite.Table("Orders")]
    public class Order : TableData
    {
      
       
        [NotNull, SQLiteNetExtensions.Attributes.ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [NotNull]
        public DateTime OrderDate { get; set; }
        [NotNull]
        public string Status { get; set; }  

        [NotNull]
        public decimal TotalAmount { get; set; }
        [ManyToOne]
        public User User { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrderItem> OrderItems { get; set; }

    }
}
