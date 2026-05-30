using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4_Restaurant_Order_System.Properties
{
     class OrderItem
    {
        public MenuItem MenuItem { get; private set; }
        public int Quantity { get; private set; }
        public string SpecialInstructions { get; private set; }

        public OrderItem(MenuItem menuItem, int quantity, string specialInstructions)
        {
            if (menuItem == null)
                return;

            this.MenuItem = menuItem;
            this.Quantity = quantity;
            this.SpecialInstructions = specialInstructions;
        }

        public decimal GetSubTotal() => Quantity * MenuItem.Price;

        public string GetOrderItemDetails() => $"- {MenuItem.Name} x{Quantity} - ${Math.Round(GetSubTotal(), 2)}\n  Special: {SpecialInstructions}";

    }
}
