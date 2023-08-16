using System;
namespace CreatingTables.Models
{
    public class NewCustomer
    {
        public NewCustomer()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int ContactNumber { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Address + " " + ContactNumber + " " + Email + " " + Status;
        }
    }
}

