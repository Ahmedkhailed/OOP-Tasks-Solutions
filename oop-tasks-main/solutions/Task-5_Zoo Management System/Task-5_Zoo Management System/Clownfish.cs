using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Clownfish : Animal
    {
        public bool HasAnemoneHost { get; private set; }
        public int StripeCount { get; private set; }

        public Clownfish(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, bool HasAnemoneHost, int stripeCount)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.HasAnemoneHost = HasAnemoneHost;
            this.StripeCount = stripeCount;
        }

        public override string MakeSound() => "Chirp";

        public override string GetHabitat() => "Coral Reef";
    }
}
