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
    [SQLite.Table("Orders")]
    public class Order : TableData
    {
       
        [NotNull]
        public int UserId { get; set; }
        [NotNull]
        public int ProductId { get; set; }

        [NotNull]
        public DateTime OrderDate { get; set; }

        [NotNull]
        public decimal TotalAmount { get; set; }
       

        
    }
}
