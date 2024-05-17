using Degree.MVVM.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Models
{
    [SQLite.Table("OrderItems")]
    public class OrderItem : TableData
    {
       
        [NotNull]
        public int OrderId { get; set; }

        [NotNull]
        public int ProductId { get; set; }

        [NotNull]
        public int Quantity { get; set; }

        [NotNull]
        public decimal UnitPrice { get; set; }
 
    }
}
