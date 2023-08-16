using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CreatingTables.Models;

namespace CreatingTables.Models
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string Category { get; set; }

        public ProductDetails ProductDetails { get; set; }

        public List<Order> Orders { get; set; }


        public override string? ToString()
        {
            return Id + " " + ProductName + " " + Price + " " + StockQuantity;
        }

    }
}




