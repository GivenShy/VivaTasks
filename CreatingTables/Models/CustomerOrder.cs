using System;
namespace CreatingTables.Models
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {

        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
    }
}

