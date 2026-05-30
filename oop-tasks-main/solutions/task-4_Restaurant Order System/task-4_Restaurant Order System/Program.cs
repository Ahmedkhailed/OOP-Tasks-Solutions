using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_4_Restaurant_Order_System.Properties;

namespace task_4_Restaurant_Order_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create restaurant
            Restaurant restaurant = new Restaurant("Tasty Bites", 0.08m);

            // Create menu items
            MenuItem burger = new MenuItem("M001", "Classic Burger", "Beef patty with lettuce, tomato, cheese", 12.99m, "Main Course");
            MenuItem fries = new MenuItem("M002", "French Fries", "Crispy golden fries", 4.99m, "Appetizer");
            MenuItem salad = new MenuItem("M003", "Caesar Salad", "Fresh romaine with caesar dressing", 8.99m, "Appetizer");
            MenuItem soda = new MenuItem("M004", "Soft Drink", "Coca-Cola, Sprite, or Fanta", 2.99m, "Beverage");
            MenuItem cake = new MenuItem("M005", "Chocolate Cake", "Rich chocolate layer cake", 6.99m, "Dessert");
            List<MenuItem> ComboItems = new List<MenuItem>() { burger, fries, soda };
            ComboMeal comboMeal = new ComboMeal("1", "Combo 1", ComboItems, "burger and fries and soda", .05m);
            MenuItem comboItem = comboMeal.ComboItem;
            

            // Add items to menu
            restaurant.Menu.AddMenuItem(burger);
            restaurant.Menu.AddMenuItem(fries);
            restaurant.Menu.AddMenuItem(salad);
            restaurant.Menu.AddMenuItem(soda);
            restaurant.Menu.AddMenuItem(cake);
            restaurant.Menu.AddMenuItem(comboItem);

            // Display menu
            restaurant.Menu.DisplayMenu();

            // Create order for table 5
            Order order1 = restaurant.CreateOrder(5);
            order1.AddItem(burger, 2, "No onions");
            order1.AddItem(fries, 2, "Extra crispy");
            order1.AddItem(soda, 2, "No ice");

            Order order2 = restaurant.CreateOrder(7);
            order2.AddItem(comboItem, 1, "No Instrctions");
            // Display order summary
            Console.WriteLine(order1.GetOrderSummary());

            // Calculate with tip
            decimal subtotal = order1.GetSubTotal();
            decimal tax = order1.GetTax();
            decimal tip = order1.CalculateTip(0.15m);  // 15% tip
            decimal total = order1.GetTotal() + tip;

            Console.WriteLine("\nSubtotal: $" + Math.Round(subtotal, 2));
            Console.WriteLine("Tax (8%): $" + Math.Round(tax, 2));
            Console.WriteLine("Tip (15%): $" + Math.Round(tip, 2));
            Console.WriteLine("Total: $" + Math.Round(total, 2));

            // Update order status
            order1.UpdateStatus("Preparing");
            Console.WriteLine("\nOrder status: " + order1.Status);

            order1.UpdateStatus("Ready");
            Console.WriteLine("Order status: " + order1.Status);

            // Complete order
            restaurant.CompletedOrder(order1.OrderID);
            Console.WriteLine("Order status: " + order1.Status);


            Console.WriteLine(order2.GetOrderSummary());

             subtotal = order2.GetSubTotal();
             tax = order2.GetTax();
             tip = order2.CalculateTip(0.15m);  // 15% tip
             total = order2.GetTotal() + tip;

            Console.WriteLine("\nSubtotal: $" + Math.Round(subtotal, 2));
            Console.WriteLine("Tax (8%): $" + Math.Round(tax, 2));
            Console.WriteLine("Tip (15%): $" + Math.Round(tip, 2));
            Console.WriteLine("Total: $" + Math.Round(total, 2));

            // Update order status
            order2.UpdateStatus("Preparing");
            Console.WriteLine("\nOrder status: " + order2.Status);

            order2.UpdateStatus("Ready");
            Console.WriteLine("Order status: " + order2.Status);

            // Complete order
            restaurant.CompletedOrder(order2.OrderID);
            Console.WriteLine("Order status: " + order2.Status);

            // Get revenue
            Console.WriteLine("\nTotal Revenue: $" + Math.Round(restaurant.GetTotalRevenue(), 2));
        }
    }
}
