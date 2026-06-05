using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Zookeeper
    {
        public string EmployeeId { get;  }
        public string Name { get; private set; }
        public string Specialization { get; private set; }
        public List<Animal> AssignedAnimals { get; private set; }

        public Zookeeper(string employeesId, string name, string specialization)
        {
            this.EmployeeId = employeesId;
            this.Name = name;
            this.Specialization = specialization;
            this.AssignedAnimals = new List<Animal>();
        }

        public void FeedAnimal(Animal animal)
        {
            Console.WriteLine($"{Name} fed {animal.Name} ({animal.Species})");
        }

        public void CheckHealth(Animal animal)
        {
            Console.WriteLine($"{Name} checked health of {animal.Name} ({animal.Species}) - Status: {animal.HealthStatus}");
        }

        public void AssignedAnimal(Animal animal)
        {
            if (animal == null)
                return;

            AssignedAnimals.Add(animal);
        }

        public bool IsAssignedAnimal(string animalId) => AssignedAnimals.Any(x => x.AnimalId == animalId);

        public void UnassignedAnimal(Animal animal)
        {
            if (animal == null)
                return;

            AssignedAnimals.Remove(animal);
        }

        public int GetWorkLoad() => AssignedAnimals.Count;
    }
}
