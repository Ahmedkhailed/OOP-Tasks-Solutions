using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Snake : Animal
    {
        public bool IsVenomous { get; private set; }
        public float Length { get; private set; }

        public Snake( string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, bool isVenomous, float length)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.IsVenomous = isVenomous;
            this.Length = length;
        }

        public override string MakeSound() => "Hiss!";

        public override string GetHabitat() => "Desert";

    }
}
