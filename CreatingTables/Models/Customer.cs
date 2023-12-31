﻿using System;
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

        public string Status { get; set; }

        public string Country { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<CallDetail> callDetails { get; set; }

        public int avarageTime { get; set; }

        public ICollection<Order> Orders { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Address + " " + ContactNumber + " " + Email + " " + Status;
        }
    }
}

