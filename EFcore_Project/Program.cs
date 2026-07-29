using EFcore_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFcore_Project
{
    internal class Program
    {
        // Shared DbContext - created ONCE, here, so every function below reuses
        // the exact same instance instead of each function opening its own.
        static ProjectContext context = new ProjectContext();
        // Shared login state - 0 means "nobody is logged in".
        // Set by Login(), read by any function that requires a logged-in user,
        // reset back to 0 by Logout().
        static int loggedInUserId = 0;
        static void Main(string[] args) 
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== E-Commerce Console App =====");
                Console.WriteLine(" 1. Register New User");
                Console.WriteLine(" 2. Login");
                Console.WriteLine(" 3. Add New Category");
                Console.WriteLine(" 4. Add New Product");
                Console.WriteLine(" 5. View All Products");
                Console.WriteLine(" 6. Place an Order");
                Console.WriteLine(" 7. View My Orders");
                Console.WriteLine(" 8. View Order Details");
                Console.WriteLine(" 9. Add a Review for an Order");
                Console.WriteLine("10. View All Reviews for a Product");
                Console.WriteLine("11. Logout");
                Console.WriteLine(" 0. Exit");
                Console.Write("Enter your choice: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1: RegisterUser(); break;
                    case 2: Login(); break;
                    case 3: AddCategory(); break;
                    case 4: AddProduct(); break;
                    case 5: ViewAllProducts(); break;
                    case 6: PlaceOrder(); break;
                    case 7: ViewMyOrders(); break;
                    case 8: ViewOrderDetails(); break;
                    case 9: AddReview(); break;
                    case 10: ViewReviewsForProduct(); break;
                    case 11: Logout(); break;
                    case 0:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // ===================== FUNCTIONS =====================
        // Every function below talks to the console itself AND uses the
        // shared "context" field declared above - never create a new
        // AppDbContext() inside any of these functions.
        static void RegisterUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            User newUser = new User();
            newUser.userName = username;
            newUser.password = password;

            context.users.Add(newUser);
            context.SaveChanges();
            Console.WriteLine("User registered successfully!");
        }
        static void Login()
        {
            if (loggedInUserId != 0)
            {
                Console.WriteLine("A user is already logged in. Please logout first.");
                return;
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            Console.WriteLine("Checking credentials...");
            User user = context.users.FirstOrDefault(u => u.userName == username && u.password == password)!;
            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }

            loggedInUserId = user!.userId;
            Console.WriteLine("Login successful!");
        }
        static void AddCategory()
        {
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine()!;

            Category newCategory = new Category();
newCategory.categoryName = categoryName;
            newCategory.categoryName = categoryName;

            context.categories.Add(newCategory);
            context.SaveChanges();
            Console.WriteLine("Category added successfully!");
        }
        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine()!;

            Console.Write("Enter product price: ");
            double productPrice = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Fetching categories...");
            List<Category> categories = context.categories.ToList();
            Console.WriteLine("Available categories:");
            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.categoryId}) {category.categoryName}");
            }

            Console.Write("Select a category ID: ");
            int categoryId = int.Parse(Console.ReadLine()!);

            Category selectedCategory = context.categories.FirstOrDefault(c => c.categoryId == categoryId)!;

            if (selectedCategory == null)
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            Product newProduct = new Product();
            newProduct.productName = productName;
            newProduct.productPrice = productPrice;
            newProduct.categoryId = categoryId;

            context.products.Add(newProduct);
            context.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
        static void ViewAllProducts()
        {
            Console.WriteLine("Fetching products...");
            List<Product> products = context.products.ToList();
            Console.WriteLine("===== All Products =====");
            Console.WriteLine("ID\tName\tPrice\tCategory");
            foreach (Product product in products)
            {
                string category = context.categories.Where(c => c.categoryId == product.categoryId).First().categoryName;
                Console.WriteLine($"{product.productId}\t{product.productName}\t{product.productPrice}\t{category}");
            }
        }
        static void PlaceOrder()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to place an order.");
                return;
            }

            ViewAllProducts();

            List<OrderProducts> orderProducts = new List<OrderProducts>();

            while (true)
            {
                Console.Write("Enter product ID to add to order (or 0 to finish): ");
                int productId = int.Parse(Console.ReadLine()!);

                if (productId == 0) break;

                Product selectedProduct = context.products.FirstOrDefault(p => p.productId == productId)!;
                if (selectedProduct == null)
                {
                    Console.WriteLine("Invalid product ID.");
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine()!);

                OrderProducts orderedProduct = new OrderProducts();
                orderedProduct!.productId = productId;
                orderedProduct.quantity = quantity;

                OrderProducts existingProduct = orderProducts.FirstOrDefault(op => op.productId == productId)!;
                if (existingProduct != null)
                {
                    existingProduct.quantity += quantity;
                    continue;
                }

                orderProducts.Add(orderedProduct);
            }

            Order newOrder = new Order();
            newOrder.userId = loggedInUserId;
            newOrder.orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            newOrder.products = orderProducts;

            context.orders.Add(newOrder);
            context.SaveChanges();
            Console.WriteLine("Order placed successfully!");
        }
        static void ViewMyOrders()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to view your orders.");
                return;
            }

            Console.WriteLine("Fetching your orders...");
            List<Order> orders = context.orders.Where(o => o.userId == loggedInUserId)
                                               .Include(o => o.products)
                                               .ToList();

            if (orders.Count == 0)
            {
                Console.WriteLine("You have no orders.");
                return;
            }

            Console.WriteLine("===== My Orders =====");
            Console.WriteLine("ID\tDate\t\t\tProducts");

            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.orderId}\t{order.orderDate}\t{order.products.Count} products");
            }
        }
        static void ViewOrderDetails()
        {
            Console.Write("Enter order ID to view details: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Fetching order details...");
            Order order = context.orders.Include(o => o.products)
                                        .FirstOrDefault(o => o.orderId == orderId)!;
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            double totalPrice = 0;
            foreach (OrderProducts op in order.products)
            {
                Product product = context.products.FirstOrDefault(p => p.productId == op.productId)!;
                Console.WriteLine($"Product: {product.productName}\tQuantity: {op.quantity}\tPrice: {product.productPrice}");
                totalPrice += op.quantity * product.productPrice;
            }

            Console.WriteLine($"Total Price: {totalPrice}");
        }
        static void AddReview()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to add a review.");
                return;
            }

            Console.Write("Enter order ID to review: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Order order = context.orders.FirstOrDefault(o => o.orderId == orderId && o.userId == loggedInUserId)!;
            if (order == null)
            {
                Console.WriteLine("Order not found or you are not the owner of this order.");
                return;
            }

            Review userReview = context.reviews.FirstOrDefault(r => r.orderId == orderId && r.order.userId == loggedInUserId)!;
            if (userReview != null)
            {
                Console.WriteLine("You have already reviewed this order.");
                return;
            }

            Console.Write("Enter your review: ");
            string reviewText = Console.ReadLine()!;

            Review newReview = new Review();
            newReview.reviewComment = reviewText;
            newReview.reviewDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            newReview.orderId = orderId;
            newReview.order = order;

            order.review = newReview;
            context.reviews.Add(newReview);

            context.SaveChanges();
            Console.WriteLine("Review added successfully!");
        }
        static void ViewReviewsForProduct()
        {
            List<Product> products = context.products.ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("===== Products =====");
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.productId}) {product.productName}");
            }

            Console.Write("Enter product ID to view reviews: ");
            int productId = int.Parse(Console.ReadLine()!);

            List<OrderProducts> orderProducts = context.orderProducts.Where(op => op.productId == productId).ToList();

            Console.WriteLine($"Reviews for Product ID {productId}:");
            foreach (OrderProducts op in orderProducts)
            {
                Review review = context.reviews.FirstOrDefault(r => r.orderId == op.orderId)!;
                if (review != null)
                {
                    Console.WriteLine($"Review for Order ID {op.orderId}: {review.reviewComment} (Date: {review.reviewDate})");
                }
            }
        }
        static void Logout()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            loggedInUserId = 0;
            Console.WriteLine("Logged out successfully!");
        }
    }
}