using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4_Restaurant_Order_System.Properties
{
     class Menu
    {
        public string RestaurantName { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }

        public Menu(string restaurantName)
        {
            this.RestaurantName = restaurantName;
            this.MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem item)
        {
            if (item == null)
                return;

            MenuItems.Add(item);
        }

        public void RemoveMenuItem(string itemID) => MenuItems.RemoveAll(x => x.ItemID.Equals(itemID));

        public List<MenuItem> GetItemsByCategory(string category) => MenuItems.Where(x => x.Category.Equals(category)).ToList();

        public List<MenuItem> SearchItems(string keyword) => MenuItems.Where(x => x.Name.Equals(keyword)).ToList();

        public void DisplayMenu()
        {
            Console.WriteLine($"=== {RestaurantName} Menu ===");

            foreach (var item in MenuItems.GroupBy(x => x.Category).OrderByDescending(x => x.Count()))
            {
                Console.WriteLine($"\n{item.Key}:");
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.GetItemInfo());
                }
            }
        }
    }
}
