using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatingTables.Models
{
    [Table("Customers")]
    public class Customer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int ContactNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

