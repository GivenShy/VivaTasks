using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatingTables.Models
{
    public class FeaturedProduct
    {
        public FeaturedProduct()
        {
        }

        public int Id { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public string Category { get; set; }


    }
}

