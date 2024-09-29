using ConsoleApp1.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
        {
            new Customer
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                City = "Ramallah",
                PurchasedProducts = new List<Product>
                {
                    new Product { ProductId = 101, ProductName = "Laptop", Price = 999.99m },
                    new Product { ProductId = 102, ProductName = "Smartphone", Price = 499.99m }
                }
            },
            new Customer
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "987-654-3210",
                City = "Gaza",
                PurchasedProducts = new List<Product>
                {
                    new Product { ProductId = 103, ProductName = "Tablet", Price = 299.99m }
                }
            },
            new Customer
            {
                Id = 3,
                Name = "Bob Johnson",
                Email = "bob.johnson@example.com",
                Phone = "555-555-5555",
                City = "Nablus",
                PurchasedProducts = new List<Product>
                {
                    new Product { ProductId = 104, ProductName = "Gaming Console", Price = 399.99m },
                    new Product { ProductId = 105, ProductName = "Headphones", Price = 199.99m }
                }
            },
            new Customer
            {
                Id = 4,
                Name = "Alice Brown",
                Email = "alice.brown@example.com",
                Phone = null,  
                City = "Hebron",
                PurchasedProducts = new List<Product>
                {
                    new Product { ProductId = 106, ProductName = "Smartwatch", Price = 149.99m }
                }
            },
            new Customer
            {
                Id = 5,
                Name = "Charlie Davis",
                Email = "charlie.davis@example.com",
                Phone = "123-123-1234",
                City = "Nablus",
                PurchasedProducts = null 
            }
        };

            //"Nablus"  كيف يمكنك الحصول على العملاء الذين يعيشون في مدينة 
            var NablusCustomer = customers.Where(customer => customer.City == "Nablus").ToList();
            Console.WriteLine("Customers who live in Nablus: ");
            NablusCustomer.ForEach(customr => Console.WriteLine($"Namw: {customr.Name}"));
            Console.WriteLine($"=====================================================================");

            // كيف يمكنك استخراج أسماء جميع العملاء من قائمة العملاء؟
            var CustomersName = customers.Select(customer => $"Name: {customer.Name}").ToList();
            Console.WriteLine($"Customers Name:");
            CustomersName.ForEach(customr => Console.WriteLine($"{customr}"));
            Console.WriteLine($"=====================================================================");

            // كيف يمكنك ترتيب العملاء بحسب أسمائهم بترتيب تصاعدي؟
            var CustomerOrders = customers.OrderBy(customer => customer.Name).ToList();
            Console.WriteLine($"Orders Customers: ");
            CustomerOrders.ForEach(customr => Console.WriteLine($"Name: {customr.Name}"));
            Console.WriteLine($"=====================================================================");

            // كيف يمكنك الحصول على أول عميل في القائمة؟
            var TopCustomer = customers.FirstOrDefault();
            if ( TopCustomer is not null )
            Console.WriteLine($"Top Customer: {TopCustomer.Name}");
            else Console.WriteLine("The List is Empty");
            Console.WriteLine($"=====================================================================");

            // Id = 1  كيف يمكنك الحصول على العميل الذي يحمل 
            var CustomerId = customers.FirstOrDefault(customer => customer.Id == 1);
            if (CustomerId is not null)
                Console.WriteLine($"Customer: {CustomerId.Name}");
            else Console.WriteLine("No Customer");
            Console.WriteLine($"=====================================================================");

            // كيف يمكنك حساب مجموع أسعار المنتجات التي اشتراها جميع العملاء؟
            var TotalPrice = customers.Where(customer => customer.PurchasedProducts != null).SelectMany(c => c.PurchasedProducts).Sum(p => p.Price);
            Console.WriteLine($"TotalPrice: {TotalPrice}");

            // OR
            decimal totalPrice = 0;

            foreach (var customer in customers)
            {
                if (customer.PurchasedProducts != null)
                {
                    totalPrice += customer.PurchasedProducts.Sum(p => p.Price); 
                }
            }
            Console.WriteLine($"=====================================================================");


            //"Qalqilia" كيف يمكنك التحقق مما إذا كان هناك أي عميل يعيش في مدينة 
            var Qalqilia = customers.Any(c => c.City == "Qalqilia");
            if (Qalqilia)
            {
                Console.WriteLine("There is a customer living in the city of Qalqilia.");
            }
            else
            {
                Console.WriteLine("There is no customer living in the city of Qalqilia.");
            }
            Console.WriteLine($"=====================================================================");

            // كيف يمكنك تجميع العملاء حسب مدينتهم؟
            var CustomersCity = customers.GroupBy(c => c.City);
            foreach (var city in CustomersCity)
            {
                Console.WriteLine($"City: {city.Key}");
                foreach (var customer in city) 
                {
                    Console.WriteLine($"  Customer Name: {customer.Name}");
                }
            }

            Console.WriteLine($"=====================================================================");
            // كيف يمكنك الحصول على أول ثلاثة عملاء من قائمة العملاء؟
            var Top3Customers = customers .Take(3).ToList();
            Top3Customers .ForEach(c => Console.WriteLine($"Name: {c.Name}"));

        }
    }
}
