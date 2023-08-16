using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatingTables.Models
{
    public class CancelledOrder
    {
        public CancelledOrder()
        {
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; }



    }
}

