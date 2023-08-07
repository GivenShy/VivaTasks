using CreatingTables;
using CreatingTables.Models;

using (ApplicationContext applicationContext = new ApplicationContext())
{
    Customer customers = new Customer();
    customers.Name = "Jivan";
    customers.ContactNumber = 82921891;
    customers.Address = "asdjh";
    customers.Email = "jivan241003@gmail.com";

    Customer customer = new Customer();
    customer.Name = "Hakob";
    customer.ContactNumber = 82921891;
    customer.Address = "sada";
    customer.Email = "jivan241003@gmail.com";
    applicationContext.Customers.Add(customers);
    applicationContext.SaveChanges();
    applicationContext.Customers.Add(customer);
    applicationContext.SaveChanges();
    Console.WriteLine(applicationContext.Customers.ToList());
}

