using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatingTables.Models
{
    [Table("ProductDetails")]
    public class ProductDetails
    {
        public ProductDetails()
        {
        }

        public int Id { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}

