using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Monkey : Animal
    {
        public string TailLength { get; private set; }
        public string FavoriteFood { get; private set; }

        public Monkey( string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, string tailLength, string favoriteFood)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.TailLength = tailLength;
            this.FavoriteFood = favoriteFood;
        }

        public override string MakeSound() => "Ooh ooh ah ah!";

        public override string GetHabitat() => "Rainforest";

    }
}
