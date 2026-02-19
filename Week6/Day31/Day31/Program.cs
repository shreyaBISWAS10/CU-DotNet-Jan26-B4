using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Day31
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
    }
    class Sale
    {
        public int ProductId;
        public int Qty;
    }

    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;
    }
    class Customer
    {
        public int Id;
        public string Name;
        public string City;
    }
    class Order
    {
        public int OrderId;
        public int CustomerId;
        public double Amount;
    }
    class Movie { 
        public string Title; 
        public string Genre; 
        public double Rating; 
        public int Year; 
    }
    class Transaction { 
        public int Acc;
        public double Amount; 
        public string Type; 
    }
    class CartItem { 
        public string Name; 
        public string Category; 
        public double Price; 
        public int Qty; 
    }

    class User { 
        public int Id; 
        public string Name; 
        public string Country; 
    }
    class Post { 
        public int UserId; 
        public int Likes; 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };
            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };
            var customers = new List<Customer> { new Customer { Id = 1, Name = "Ajay", City = "Delhi" }, new Customer { Id = 2, Name = "Sunita", City = "Mumbai" } };
            var orders = new List<Order> { new Order { OrderId = 1, CustomerId = 1, Amount = 20000 }, new Order { OrderId = 2, CustomerId = 1, Amount = 40000 } };

            var movies = new List<Movie> { new Movie { Title = "Inception", Genre = "SciFi", Rating = 9, Year = 2010 }, new Movie { Title = "Avatar", Genre = "SciFi", Rating = 8.5, Year = 2009 }, new Movie { Title = "Titanic", Genre = "Drama", Rating = 8, Year = 1997 } };

            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //1st question
            Console.WriteLine("1st question");
            Console.WriteLine("Top 3 students are: ");

            //Top 3 students by marks
            var top3WithMarks = students.OrderByDescending(x => x.Marks).Take(3);
            foreach (var student in top3WithMarks)
            {
                Console.WriteLine(student.Name + " - " + student.Marks);
            }
            Console.WriteLine();

            //Group students by class and calculate average and students below average scores


            Console.Write("Students who scored below class average are: ");

            foreach (var group in students.GroupBy(s => s.Class))
            {
                double classAverage = group.Average(s => s.Marks);

                Console.WriteLine($"\nClass {group.Key} (Average: {classAverage})");

                var belowAverageStudents = group.Where(s => s.Marks < classAverage);

                foreach (var student in belowAverageStudents)
                {
                    Console.WriteLine(student.Name + " - " + student.Marks);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Students ordred by marks and class:");

            //Order students by class and marks
            var orderStudents = students.OrderBy(s => s.Class).OrderByDescending(students => students.Marks);
            foreach (var student in orderStudents)
            {
                Console.WriteLine(student.Name + " - " + student.Marks);
            }
            Console.WriteLine();


            //2nd question
            Console.WriteLine("2nd Question");
            Console.WriteLine("Highest and lowest salary in each dept is:");

            foreach (var group in employees.GroupBy(s => s.Dept))
            {
                double min = group.Min(e => e.Salary);
                double max = group.Max(e => e.Salary);
                Console.WriteLine($"\nDepartment-{group.Key} (Maximum Salary: {max}) (Minimum Salary: {min})");

            }
            Console.WriteLine();

            Console.WriteLine("Count of employees in each department:");

            foreach (var group in employees.GroupBy(s => s.Dept))
            {
                var countOfEployees = group.Count();
                Console.WriteLine($"{group.Key} {countOfEployees}");

            }
            Console.WriteLine();

            Console.WriteLine("Students who joined after 2020:");
            var empJoinedAfter2020 = employees.Where(x => x.JoinDate.Year > 2020);
            foreach (var employee in empJoinedAfter2020)
            {
                Console.WriteLine($"{employee.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Anonymous objects with name and annual salary:");
            var objectWithNameAndSal = employees.Select(e => new
            {
                e.Name,
                AnnualSalary = e.Salary * 12
            });
            foreach (var emp in objectWithNameAndSal)
            {
                Console.WriteLine($"{emp.Name} - {emp.AnnualSalary}");
            }
            Console.WriteLine();

            //3rd question
            //Join Products with Sales +Total Revenue per Product

            Console.WriteLine("Joined Products & Sales ");

            var join = products.Join(
                sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new { p.Name, s.Qty }
            );

            foreach (var j in join)
                Console.WriteLine($"{j.Name} ,  Sold: {j.Qty}");


            Console.WriteLine("\nRevenue Per Product");

            var revenue = products.Join(
                sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new { p.Name, Revenue = p.Price * s.Qty }
            );
            foreach (var r in revenue)
                Console.WriteLine($"{r.Name} , Revenue: {r.Revenue}");


            Console.WriteLine("\nBest Selling Product");

            var best = sales
                .OrderByDescending(s => s.Qty)
                .First();

            var bestProduct = products.First(p => p.Id == best.ProductId);

            Console.WriteLine($"{bestProduct.Name} , Sold: {best.Qty}");


            Console.WriteLine("\nProducts With No Sales");

            var zeroSales = products
                .GroupJoin(
                    sales,
                    p => p.Id,
                    s => s.ProductId,
                    (p, s) => new { Product = p, Sales = s })
                .Where(x => !x.Sales.Any())
                .Select(x => x.Product);

            foreach (var p in zeroSales)
                Console.WriteLine(p.Name);


            //4th question
            //Find books published after 2015
            Console.WriteLine("$th question");
            Console.WriteLine("Books After 2015: ");
            var booksAfter2015 = books.Where(x => x.Year > 2015);
            foreach (var book in booksAfter2015)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();

            //Group by Genre and count books
            Console.WriteLine("Books Grouped by Genre and Count ");
            var booksGenreCount = books
                .GroupBy(b => b.Genre)
                .Select(g => new
                {
                    Genre = g.Key,
                    Count = g.Count()
                })
                .ToList();
            foreach (var g in booksGenreCount)
            {
                Console.WriteLine($"{g.Genre}: {g.Count}");
            }
            Console.WriteLine();


            //Most Expensive book by genre
            Console.WriteLine("Most expensive book by genre: ");
            var mostExpensivePerGenre = books
                .GroupBy(b => b.Genre)
                .Select(g => g.OrderByDescending(b => b.Price)
                .FirstOrDefault())
                .ToList();

            foreach (var b in mostExpensivePerGenre)
                Console.WriteLine($"{b.Genre} , {b.Title} ({b.Price})");
            Console.WriteLine();


            //Return distinct keyword
            Console.WriteLine("Distinct Authors are:");
            var distinctAuthors = books.Select(b => b.Author).Distinct().ToList();
            foreach (var a in distinctAuthors)
                Console.WriteLine(a);
            Console.WriteLine();

            //5th question
            Console.WriteLine("5th question");
            Console.WriteLine("Total Order amount per customer :");
            var totalPerCustomer = customers
                                    .GroupJoin(
                                        orders,
                                        c => c.Id,
                                        o => o.CustomerId,
                                        (c, custOrders) => new
                                        {
                                            CustomerName = c.Name,
                                            TotalAmount = custOrders.Sum(o => o.Amount)
                                        })
                                    .ToList();
            foreach (var item in totalPerCustomer)
            {
                Console.WriteLine(item.CustomerName + " → ₹" + item.TotalAmount);
            }

            Console.WriteLine();
            Console.WriteLine("Customers with no order:");
            var customersWithNoOrders = customers
                                        .GroupJoin(
                                            orders,
                                            c => c.Id,
                                            o => o.CustomerId,
                                            (c, custOrders) => new { Customer = c, Orders = custOrders })
                                        .Where(x => !x.Orders.Any())
                                        .Select(x => x.Customer)
                                        .ToList();
            foreach (var c in customersWithNoOrders)
            {
                Console.WriteLine(c.Name + " (" + c.City + ")");
            }

            Console.WriteLine();

            Console.WriteLine("Customer who spent above 50k:");
            var highSpenders = customers
                                .GroupJoin(
                                    orders,
                                    c => c.Id,
                                    o => o.CustomerId,
                                    (c, custOrders) => new
                                    {
                                        Customer = c,
                                        Total = custOrders.Sum(o => o.Amount)
                                    })
                                    .Where(x => x.Total > 50000)
                                    .Select(x => x.Customer)
                                    .ToList();
            foreach (var c in highSpenders)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Customers sorted by total spending:");

            var sortedBySpending = customers
                                    .GroupJoin(
                                        orders,
                                        c => c.Id,
                                        o => o.CustomerId,
                                        (c, custOrders) => new
                                        {
                                            CustomerName = c.Name,
                                            Total = custOrders.Sum(o => o.Amount)
                                        })
                                        .OrderByDescending(x => x.Total)
                                        .ToList();
            foreach (var item in sortedBySpending)
            {
                Console.WriteLine(item.CustomerName + " → ₹" + item.Total);
            }
            Console.WriteLine();

            //6th question
            Console.WriteLine("6th question");
            Console.WriteLine("Moveis with rating > 8");
            var highRated = movies
                            .Where(m => m.Rating > 8)
                            .ToList();
            foreach (var m in highRated)
            {
                Console.WriteLine($"{m.Title} ({m.Rating})");
            }
            Console.WriteLine();

            Console.WriteLine("Movies grouped by genre and average rating: ");
            var avgRatingByGenre = movies
                                    .GroupBy(m => m.Genre)
                                    .Select(g => new
                                    {
                                        Genre = g.Key,
                                        AvgRating = g.Average(m => m.Rating)
                                    })
                                    .ToList();
            foreach (var g in avgRatingByGenre)
            {
                Console.WriteLine($"{g.Genre} → Avg Rating: {g.AvgRating}");
            }

            Console.WriteLine();
            Console.WriteLine("Latest movie per Genre: ");

            var latestPerGenre = movies
                                .GroupBy(m => m.Genre)
                                .Select(g => g
                                .OrderByDescending(m => m.Year)
                                .FirstOrDefault());
            
            foreach (var m in latestPerGenre)
                Console.WriteLine($"{m.Genre} - {m.Title} ({m.Year})");



            // Top 5 highest-rated movies
            var top5 = movies
                .OrderByDescending(m => m.Rating)
                .Take(5);

            Console.WriteLine("\nTop Highest Rated Movies:");
            foreach (var m in top5)
                Console.WriteLine($"{m.Title} - {m.Rating}");

            //7th question
            // Total balance per account (Credit - Debit)
            var totalBalance = transactions
                                .GroupBy(t => t.Acc)
                                .Select(g => new
                                {
                                    Acc = g.Key,
                                    Balance = g.Where(t => t.Type == "Credit").Sum(t => t.Amount)
                                    - g.Where(t => t.Type == "Debit").Sum(transactions => transactions.Amount)
                                });
            Console.WriteLine("Total Balance Per Account:");
            foreach (var b in totalBalance)
                Console.WriteLine($"Account {b.Acc} - Balance: {b.Balance}");

            // Suspicious accounts(Debit > Credit)
            var suspicious = transactions
                            .GroupBy(t => t.Acc)
                            .Where(g =>
                                    g.Where(t => t.Type == "Debit").Sum(t => t.Amount) >
                                    g.Where(t => t.Type == "Credit").Sum(t => t.Amount))
                                    .Select(g => g.Key);

            Console.WriteLine("\nSuspicious Accounts (Debit > Credit):");
            foreach (var acc in suspicious)
                Console.WriteLine($"Account {acc}");


            // Highest transaction per account
            var highest = transactions
                .GroupBy(t => t.Acc)
                .Select(g => new
                {
                    Acc = g.Key,
                    MaxTransaction = g.Max(t => t.Amount)
                });
            //highest transaction per account
            Console.WriteLine("\nHighest Transaction Per Account:");
            foreach (var h in highest)
                Console.WriteLine($"Account {h.Acc} - Highest: {h.MaxTransaction}");

            //8th question

            //total cart value
            Console.WriteLine("Total Cart Value");

            var total = cart.Sum(c => c.Price * c.Qty);
            Console.WriteLine($"Total: {total}");

            //category wise cost
            Console.WriteLine("\nCategory Wise Cost");

            var categoryCost = cart
                .GroupBy(c => c.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(c => c.Price * c.Qty)
                });

            foreach (var c in categoryCost)
                Console.WriteLine($"{c.Category} → {c.Total}");

            //electronics discount
            Console.WriteLine("\nElectronics Discount (10%) ");

            var discount = cart
                .Where(c => c.Category == "Electronics")
                .Select(c => new
                {
                    c.Name,
                    DiscountedPrice = c.Price * c.Qty * 0.9
                });

            foreach (var d in discount)
                Console.WriteLine($"{d.Name} , {d.DiscountedPrice}");


            //cart summary
            Console.WriteLine("\nCart Summary DTO");

            var summary = cart.Select(c => new
            {
                c.Name,
                c.Category,
                TotalCost = c.Price * c.Qty
            });

            foreach (var s in summary)
                Console.WriteLine($"{s.Name} ({s.Category}) , {s.TotalCost}");



            //9th question
            //Top users by likes
            Console.WriteLine("Top Users by Likes");

            var topUsers = posts
                .GroupBy(p => p.UserId)
                .Select(g => new { UserId = g.Key, TotalLikes = g.Sum(p => p.Likes) })
                .OrderByDescending(x => x.TotalLikes);

            foreach (var u in topUsers)
                Console.WriteLine($"User {u.UserId} , Likes: {u.TotalLikes}");


            //users by country
            Console.WriteLine("\nUsers by Country");

            var byCountry = users.GroupBy(u => u.Country);

            foreach (var g in byCountry)
            {
                Console.WriteLine($"Country: {g.Key}");
                foreach (var u in g)
                    Console.WriteLine($"  {u.Name}");
            }

            //Inactive users(no posts)
        Console.WriteLine("\nInactive Users");

            var inactive = users
                .GroupJoin(posts,
                    u => u.Id,
                    p => p.UserId,
                    (u, p) => new { User = u, Posts = p })
                .Where(x => !x.Posts.Any())
                .Select(x => x.User);

            foreach (var u in inactive)
                Console.WriteLine(u.Name);

            //Average likes per post
        Console.WriteLine("\nAverage Likes Per Post");

            var avgLikes = posts.Average(p => p.Likes);
            Console.WriteLine(avgLikes);





        }
    }
}
