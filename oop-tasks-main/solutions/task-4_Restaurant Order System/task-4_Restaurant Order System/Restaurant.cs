using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_4_Restaurant_Order_System.Properties;

namespace task_4_Restaurant_Order_System
{
     class Restaurant
    {
        public string RestaurantName { get; private set; }
        public Menu Menu { get; private set; }
        public List<Order> Orders { get; private set; }
        public decimal TaxRate { get; private set; }
        private static int OrderNumber = 0;

        public Restaurant(string restaurantName, decimal taxRate)
        {
            this.RestaurantName = restaurantName;
            this.Menu = new Menu(restaurantName);
            this.Orders = new List<Order>();
            this.TaxRate = taxRate;
            OrderNumber++;
        }

        public Order CreateOrder(int tableNumber)
        {
            Order order = new Order($"O-{OrderNumber}", tableNumber);
            Orders.Add(order);
            return order;
        }

        public void GetOrder(string orderId) => Orders.Find(x => x.OrderID.Equals(orderId));

        public List<Order> GetOrdersByStatus(string Status) => Orders.FindAll(x => x.Status.Equals(Status));

        public List<Order> GetActiveOrders() => Orders.FindAll(x => !x.Status.Equals("Completed"));

        public void CompletedOrder(string orderID)
        {
            if (!Orders.Any())
                return;

            Orders.Find(x => x.OrderID == orderID).UpdateStatus("Completed");
        }

        public decimal GetTotalRevenue() => Orders.Where(x => x.Status.Equals("Completed")).Sum(x => x.GetTotal());

        public List<OrderItem> GetPopularItems(int count) => Orders
            .SelectMany(x => x.OrderItems)
            .GroupBy(x => x.MenuItem)
            .OrderByDescending(x => x.Count())
            .Take(count)
            .Select(x => x.First())
            .ToList();


    }
}
