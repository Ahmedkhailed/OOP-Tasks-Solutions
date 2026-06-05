using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Crocodile : Animal
    {
        public string JawStrength { get; private set; }
        public float Weight { get; private set; }

        public Crocodile(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, string jawStrength, float weight)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.JawStrength = jawStrength;
            this.Weight = weight;
        }

        public override string MakeSound() => "Growl!";

        public override string GetHabitat() => "Swamp";

    }
}
