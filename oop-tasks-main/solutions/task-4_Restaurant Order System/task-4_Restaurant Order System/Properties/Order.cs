using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task_4_Restaurant_Order_System.Properties
{
     class Order
    {
        public string OrderID { get; }
        public int TableNumber { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public DateTime OrderTime { get; private set; }
        public string Status { get; private set; }

        public Order(string orderID, int tableNumber)
        {
            this.OrderID = OrderID;
            this.TableNumber = tableNumber;
            this.OrderItems = new List<OrderItem>();
            this.OrderTime = DateTime.Now;
            this.Status = "Pending";
        }

        public void AddItem(MenuItem menuItem, int quantity, string instructions)
        {
            if (menuItem == null)
                return;

            OrderItems.Add(new OrderItem(menuItem, quantity, instructions));
        }

        public void RemoveItem(string itemID) => OrderItems.RemoveAll(x => x.MenuItem.ItemID.Equals(itemID));

        public decimal GetSubTotal() => OrderItems.Sum(x => x.GetSubTotal());

        public decimal GetTax() => GetSubTotal() * .08m;

        public decimal GetTotal() => GetSubTotal() + GetTax();

        public decimal CalculateTip(decimal percentage) => GetSubTotal() * percentage;

        public void UpdateStatus(string newStatus) => Status = newStatus;

        public string GetOrderSummary()
        {
            string summary = "\n=== Order Summary ===";
            summary += $"\nOrder ID: {OrderID}";
            summary += $"\nTable: {TableNumber}";
            summary += $"\nTime: {OrderTime.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)}";
            summary += $"\nStatus: {Status}";

            summary += "\n\nItems:";
            foreach (var item in OrderItems)
            {
                summary += "\n" + item.GetOrderItemDetails();
            }
            return summary;
        }
    }
}
