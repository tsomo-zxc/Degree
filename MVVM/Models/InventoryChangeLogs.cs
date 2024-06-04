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
    [SQLite.Table("InventoryChangeLogs")]
    public class InventoryChangeLogs : TableData
    {
        [NotNull,ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
        [NotNull]
        public string ChangeType { get; set; }
        [NotNull]
        public int ChangeQuantity { get; set; }
        [NotNull]
        public DateTime ChangeDate { get; set; }


    }
}
