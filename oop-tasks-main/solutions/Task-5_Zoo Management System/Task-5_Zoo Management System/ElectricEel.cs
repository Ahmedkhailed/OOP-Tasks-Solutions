using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class ElectricEel : Animal
    {
        public int MaxVoltageOutput { get; private set; }
        public int AirGulpIntervalMinutes { get; private set; }

        public ElectricEel(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, int maxVoltageOutput, int airGulpIntervalMinutes)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.MaxVoltageOutput = maxVoltageOutput;
            this.AirGulpIntervalMinutes = airGulpIntervalMinutes;
        }

        public override string MakeSound() => "ElectricHum!";

        public override string GetHabitat() => "Amazon Basin";
    }
}
