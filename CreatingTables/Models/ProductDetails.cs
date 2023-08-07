using System;
namespace CreatingTables.Models
{
    public class ProductDetails
    {
        public ProductDetails()
        {
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}

