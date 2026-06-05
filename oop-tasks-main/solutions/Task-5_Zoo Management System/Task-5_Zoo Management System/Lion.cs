using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_5_Zoo_Management_System
{
    internal class Lion : Animal
    {
        public string ManeColor { get; private set; }
        public float PrideSize { get; private set; }

        public Lion(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, string maneColor, float prideSize)
            : base( animalId,  name,  species,  age,  healthStatus,  dailyFoodCost)
        {
            this.ManeColor = maneColor;
            this.PrideSize = prideSize;
        }

        public override string MakeSound() => "Roar!";

        public override string GetHabitat() => "Savanna";
    }
}
