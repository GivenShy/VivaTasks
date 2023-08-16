using System;
namespace CreatingTables.Models
{
    public class CallDetail
    {
        public CallDetail()
        {

        }

        public int Id { get; set; }
        public int CallDuration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int AvarageCallTime { get; set; }

    }
}

