﻿using Degree.MVVM.Abstractions;
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
    
        [SQLite.Table("Users")]
        public class User : TableData
        {
            
            [MaxLength(100), Unique, NotNull]
            public string Username { get; set; }

            [NotNull]
            public string PasswordHash { get; set; }

            [MaxLength(50), NotNull]
            public string Role { get; set; }

            [MaxLength(100), Unique, NotNull]
            public string Email { get; set; }
            
            [OneToMany(CascadeOperations = CascadeOperation.All)]
            public List<Order> Orders { get; set; }
            [OneToMany(CascadeOperations = CascadeOperation.All)]
            public List<Inventory> UserInventory { get; set; }

    }
    
}
