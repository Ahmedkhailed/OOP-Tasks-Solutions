using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Eagle : Animal
    {
        public float Wingspan { get; private set; }
        public float DiveSpeed { get; private set; }

        public Eagle(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, float wingspan, float diveSpeed)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.Wingspan = wingspan;
            this.DiveSpeed = diveSpeed;
        }

        public override string MakeSound() => "Screech!";

        public override string GetHabitat() => "Mountains";

    }
}
