using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_4_Restaurant_Order_System.Properties;

namespace task_4_Restaurant_Order_System
{
     class ComboMeal
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        private List<MenuItem> items { get; set; }
        public decimal DiscountRate { get; private set; }
        public string Description { get; private set; }
        public MenuItem ComboItem
        {
            get
            {
                return new MenuItem($"CI{ID}", Name, Description, CalculatePriceCombo(), "Combo Meal");
            }
        }
       
        public ComboMeal(string id, string name, List<MenuItem> items, string description , decimal discountRate)
        {
            this.ID = id;
            this.Name = name;
            this.items = items;
            this.DiscountRate = discountRate;
            this.Description = description;
        }

        private decimal CalculatePriceCombo()
        {
            if (!items.Any())
                return 0;

            decimal originalPrice = items.Sum(x => x.Price);
            return originalPrice * (1 - DiscountRate);
        }
    }
}
