using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    abstract class Animal
    {
        public string AnimalId { get; }
        public string Name { get; protected set; }
        public string Species { get; protected set; }
        public int Age { get; protected set; }
        public string HealthStatus { get; set; }
        public decimal DailyFoodCost { get; protected set; }

        public Animal(string animalId, string name, string species,int age, string healthStatus, decimal dailyFoodCost )
        {
            this.AnimalId = animalId;
            this.Name = name;
            this.Species = species;
            this.Age = age;
            this.HealthStatus = healthStatus;
            this.DailyFoodCost = dailyFoodCost;
        }

        public abstract string MakeSound();
        public abstract string GetHabitat();

        public virtual string GetAnimalInfo()
        {
            return $"{AnimalId} - {Name} ({Species}) - Age: {Age} - Habitat: {GetHabitat()}";
        }

        public virtual decimal CalculateWeeklyCost() => 7 * DailyFoodCost;
    }
}
