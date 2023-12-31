﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatingTables.Models
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public override string ToString()
        {
            return Id + " " + OrderDate + " " + CustomerId + " " + TotalAmount + " " + Status;
        }

    }
}

