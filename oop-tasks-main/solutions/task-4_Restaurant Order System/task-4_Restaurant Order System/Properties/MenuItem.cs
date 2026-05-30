using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4_Restaurant_Order_System.Properties
{
    internal class MenuItem
    {
        public string ItemID { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }    
        public decimal Price { get; private set; }
        public string Category { get; private set; }
        public bool IsAvailable { get; private set;  }

        public MenuItem(string itemID, string Name, string description, decimal price, string category)
        {
            this.ItemID = itemID;
            this.Name = Name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
            this.IsAvailable = true;
        }

        public string GetItemInfo() => $"- {Name}: {Description} - ${Math.Round(Price, 2)}";

    }
}
