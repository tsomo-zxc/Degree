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
    [SQLite.Table("Inventory")]
    public class Inventory : TableData
    {
       

        [NotNull]
        public int UserId { get; set; }

        [NotNull]
        public int ProductId { get; set; }

        [NotNull]
        public int Quantity { get; set; }

        //[ForeignKey(typeof(User))]
        //public int UserForeignKey { get; set; }

        //[ForeignKey(typeof(Product))]
        //public int ProductForeignKey { get; set; }
    }
}
