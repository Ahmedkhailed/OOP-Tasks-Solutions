using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Elephant : Animal
    {
        public float TuskLength { get; private set; }
        public float Weight { get; private set; }

        public Elephant(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, float tuskLength, float weight)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.TuskLength = tuskLength;
            this.Weight = weight;
        }

        public override string MakeSound() => "Trumpet!";

        public override string GetHabitat() => "Grassland";

    }
}
