using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using CreatingTables;
using CreatingTables.Migrations;
using CreatingTables.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using (ApplicationContext applicationContext = new ApplicationContext())
{
    //Filtering:
    //Task 1: Retrieve Active Customers
    //var customers = applicationContext.Customers.Where(c => (c.Status == "Active"));
    //foreach (Customer customer in customers)
    //{
    //    Console.WriteLine(customer.Name);
    //}
    //Console.ReadKey();

    //Product product1 = new Product { Price = 120, ProductName = "AirPods", StockQuantity = 3 };
    //Product product2 = new Product { Price = 32, ProductName = "Hat", StockQuantity = 16 };

    //applicationContext.AddRange(product1, product2);
    //applicationContext.SaveChanges();


    //Task 2: Get High-Value Products
    //var products = from prod in applicationContext.Products
    //               where prod.Price <= 100
    //               select prod;
    //foreach (var prod in products)
    //{
    //    Console.WriteLine(prod.ToString());
    //}
    //Console.ReadKey();

    //Task 3: Fetch Recent Orders
    //var orders = applicationContext.Orders.Include(o => o.Customer)
    //    .Where(o => o.OrderDate.AddDays(7) >= DateTime.Now);

    //foreach (var order in orders)
    //{
    //    Console.WriteLine(order.ToString());
    //    Console.WriteLine(order.Customer);
    //}
    //Console.Read();

    //Sorting:
    //Task 4: Sort Products by Price
    //
    //var products = applicationContext.Products.OrderBy(p => p.Price);
    //foreach (var prod in products)
    //{
    //    Console.WriteLine(prod.ToString());
    //}
    //Console.ReadKey();

    //Task 5: Sort Orders by Total Amount
    //var orders = from o in applicationContext.Orders
    //             orderby o.TotalAmount descending
    //             select o;

    //foreach (var order in orders)
    //{
    //    Console.WriteLine(order.ToString());
    //    Console.WriteLine(order.Customer);
    //}
    //Console.Read();

    //Task 6: Sort Customers Alphabetically
    //var customers = from c in applicationContext.Customers
    //                orderby c.Name
    //                select c;
    //foreach (Customer customer in customers)
    //{
    //    Console.WriteLine(customer.Name);
    //}
    //Console.ReadKey();

    //Joining:
    //Task 7: Retrieve Customer Orders
    //var orders = applicationContext.Orders.Join(applicationContext.Customers,
    //    o => o.CustomerId,
    //    c => c.Id,
    //    (o, c) => new // результат
    //    {
    //        Name = c.Name,
    //        order = o,
    //        Status = c.Status
    //    }
    //    );
    //foreach (var ord in orders)
    //{
    //    Console.WriteLine(ord.order.ToString() + " " + ord.Name + " " + ord.Status);
    //}
    //Console.ReadKey();

    //Task 8: Join Order Products

    //----harcnel

    //Task 9: Join Customer and Order Details
    //var cust = from customer in applicationContext.Customers
    //           join order in applicationContext.Orders on customer.Id equals order.CustomerId into Details
    //           from m in Details.DefaultIfEmpty()
    //           select new
    //           {
    //               Customer = customer,
    //               Order = m

    //           };

    //foreach (var temp in cust)
    //{
    //    Console.WriteLine(temp.Customer.ToString() + ", " + temp.Order?.ToString());
    //}
    //Console.ReadKey();

    //Grouping:
    //Task 10: Group Orders by Status

    //var groups = from order in applicationContext.Orders
    //             group order by order.Status into g
    //             select new
    //             {
    //                 g.Key,
    //                 Count = g.Count()

    //             };
    //foreach (var g in groups)
    //{
    //    Console.WriteLine(g.Key + " " + g.Count);
    //}
    //Console.ReadKey();

    //Task 11: Group Products by Category
    //var groups = applicationContext.Products
    //    .GroupBy(p => p.Category)
    //    .Select(k => new
    //    {
    //        k.Key,
    //        Avarage = k.Average(p => p.Price)
    //    });
    //foreach (var group in groups)
    //{
    //    Console.WriteLine(group.Key + " " + group.Avarage);
    //}

    //Task 12: Group Customers by Country
    //var groups = applicationContext.Customers
    //    .GroupBy(c => c.Country)
    //    .Select(k => new
    //    {
    //        k.Key,
    //        Count = k.Count()
    //    }).ToList();
    //foreach (var group in groups)
    //{
    //    Console.WriteLine(group.Key + " " + group.Count);
    //}

    //Union/Intersect/Except:
    //Task 13: Get Unique Customers
    //var users = applicationContext.Customers.Select(c => new
    //{
    //    Name = c.Name,
    //    Email = c.Email

    //}).Union(applicationContext.NewCustomers.Select(c => new
    //{
    //    Name = c.Name,
    //    Email = c.Email
    //}
    //));
    //foreach (var user in users)
    //{
    //    Console.WriteLine(user.Name + " " + user.Email);
    //}

    //Task 14: Find Common Products
    //var inter = applicationContext.FeaturedProducts.Select(p => new
    //{
    //    Name = p.ProductName,
    //    Category = p.Category
    //}).Intersect(applicationContext.BestSellerProducts.Select(p => new
    //{
    //    Name = p.ProductName,
    //    Category = p.Category
    //})).ToList();
    //foreach (var i in inter)
    //{
    //    Console.WriteLine(i.Category + " " + i.Name);
    //}

    //Task 15: Identify Non-Duplicate Orders
    //var exc = applicationContext.Orders.Select(o => new
    //{
    //    Date = o.OrderDate,
    //    Amount = o.TotalAmount
    //}).Except(applicationContext.CancelledOrders.Select(o => new
    //{
    //    Date = o.OrderDate,
    //    Amount = o.TotalAmount
    //}));
    //foreach (var ex in exc)
    //{
    //    Console.WriteLine(ex.Amount + " " + ex.Date);
    //}

    //Aggregation Operations:
    //Task 16: Calculate Total Order Amount
    //
    //var some = applicationContext.Orders.Sum(o => o.TotalAmount);
    //Console.WriteLine(some);

    //Task 17: Find Maximum Product Price
    //var max = applicationContext.Products.Max(p => p.Price);
    //Console.WriteLine(max);

    //Task 18: Determine Average Call Duration
    //var list = applicationContext.CallDetails.ToList();
    //foreach (var call in list)
    //{
    //    call.CallDuration = Convert.ToInt32((call.EndTime - call.StartTime).TotalSeconds);
    //}
    //applicationContext.SaveChanges();
    //var duration = applicationContext.CallDetails.Average(c => c.CallDuration);
    //Console.WriteLine(duration);

    //Tracking / AsNoTracking:
    //Task 19: Retrieve Customers with Tracking
    //applicationContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    //var customers = applicationContext.Customers.ToList();
    //customers[0].Address = "777777";
    //applicationContext.SaveChanges();

    //Task 20: Retrieve Products Without Tracking
    //var products = applicationContext.Products.AsNoTracking().ToList();
    //products[0].Category = "1234567";
    //applicationContext.SaveChanges();

    //HasQueryFilter:
    //Task 21: Apply Soft Delete Filter
    //applied in context class

    //ExecuteUpdate / ExecuteDelete:
    //Task 22: Update Product Prices
    //var products = applicationContext.Products.ToList();
    //decimal percent = 10;
    //foreach (Product product in products)
    //{
    //    product.Price = product.Price * (1 + percent / 100);
    //    Console.WriteLine(product.Price);
    //}
    //applicationContext.SaveChanges();

    //applicationContext.Products.ExecuteUpdate(c => c.SetProperty(u => u.Price, u => u.Price * (1 + percent / 100)));


    //
    //Task 23: Delete Old Orders
    //var orders = applicationContext.Orders.Where(o => o.OrderDate < DateTime.Now.AddYears(-1));
    //Console.WriteLine(orders.Count());
    //applicationContext.Orders.RemoveRange(orders);
    //applicationContext.SaveChanges();


    //
    //FromSqlRaw / ExecuteSqlRaw:
    //Task 1: Retrieve Products Using Raw SQL
    //decimal price = 500;
    //var products = applicationContext.Products.FromSqlRaw("SELECT * FROM Products where Price>{0}", price).ToList();
    //foreach (Product product in products)
    //{
    //    Console.WriteLine(product.ToString());
    //}

    //Task 2: Update Product Prices Using Raw SQL

    //decimal increaseAmount = 200;
    //string category = "Computers";
    //applicationContext.Database.ExecuteSqlRaw("UPDATE Products set Price = Price + {0} WHERE Category = {1}", increaseAmount, category);

    //FromSqlInterpolated / ExecuteSqlInterpolated:
    //Task 3: Retrieve Customers Using Interpolated SQL
    //string contactNumber = "%23%";
    //var customers = applicationContext.Customers.FromSqlInterpolated($"SELECT * FROM Customers WHERE ContactNumber LIKE {contactNumber}").ToList();

    //foreach (Customer customer in customers)
    //{
    //    Console.WriteLine(customer.ToString());
    //}

    //Task 4: Delete Inactive Customers Using Interpolated SQL
    //int months = 6;
    //var some = applicationContext.Database.ExecuteSqlInterpolated($"DELETE FROM Customers WHERE ID NOT IN (SELECT CustomerID FROM Orders WHERE DATEDIFF(MONTH,OrderDate,GETDATE())<{months})");
    //Console.Write(some);

    //Stored Functions:
    //Task 5: Use Scalar-valued Stored Function
    //var result = applicationContext.Set<MyOutput>().FromSqlRaw("select dbo.GETAGE('2003-10-24') as result").FirstOrDefault();
    //Console.WriteLine(result.Result);

    //Task 6: Use Table-valued Stored Function
    //var orders = applicationContext.Orders.FromSqlRaw("SELECT * FROM dbo.GETORDERS({0})", 2000).ToList();
    //foreach (var order in orders)
    //{
    //    Console.WriteLine(order.ToString());
    //}


    //Stored Procedures:
    //Task 7: Call a Simple Stored Procedure
    //SqlParameter param = new()
    //{
    //    ParameterName = "@count",
    //    SqlDbType = System.Data.SqlDbType.Int,
    //    Direction = System.Data.ParameterDirection.Output,
    //};
    //applicationContext.Database.ExecuteSqlRaw("GetOrderCount {0}, @count OUT", 5, param);
    //Console.WriteLine(param.Value);

    //Task 8: Execute Complex Stored Procedure
    //applicationContext.Database.ExecuteSqlRaw("UpdateAvarageTime {0}", 5);

    //Concurrency Handling:
    //Task 9: Implement Optimistic Concurrency Control
    //try
    //{
    //    Customer customer = applicationContext.Customers.FirstOrDefault();
    //    customer.Name = "Bob";
    //    applicationContext.SaveChanges();
    //    Console.WriteLine(customer.Name);
    //    throw new DbUpdateConcurrencyException();
    //}
    //catch (DbUpdateConcurrencyException ex)
    //{
    //    File.AppendAllText("/Users/jivanshmavonyan/Desktop/Tasks/CreatingTables/log.txt",
    //        "Cuncurent exception - trying to change Customer\n"
    //        + ex.Message
    //        + "\n"
    //        + "------------------------------\n");
    //}


    //Log Providers:
    //Task 10: Configure Custom Logging Provider
    //

    //Compiled Queries:
    //Task 11: Create and Use Compiled Query

    //Func<ApplicationContext, int, Customer> getById = EF.CompileQuery((ApplicationContext ap, int id) => ap.Customers.Where(c => c.Id == id).FirstOrDefault());
    //Console.WriteLine(getById(applicationContext, 4).ToString());

    //Query Projection to View:
    //Task 12: Map Query Results to a View Model
    //var view = applicationContext.CustomerOrders.ToList();
    //foreach (var v in view)
    //{
    //    Console.WriteLine(v.Name + " " + v.Amount);
    //}
    //History Management:
    //Task 13: Implement Change Tracking and History
    //Employee employee = new Employee { Name = "Jivan", Salary = 300, StartedWork = DateTime.Now };
    //applicationContext.Employees.Add(employee);
    //applicationContext.SaveChanges();
    //var employee = applicationContext.Employees.FirstOrDefault();
    //employee.Name = "Tiago";
    //applicationContext.SaveChanges();

}

public class MyOutput
{

    public int Result { get; set; }
}

