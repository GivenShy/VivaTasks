using System;
namespace CreatingTables.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public DateTime StartedWork { get; set; }
    }
}

