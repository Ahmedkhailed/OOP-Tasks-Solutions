using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Zoo
    {
        public string ZooName { get; private set; }
        public List<Animal> Animals { get; private set; }
        public List <Zookeeper> Zookeepers { get; private set; }

        public Zoo(string zooName)
        {
            this.ZooName = zooName;
            this.Animals = new List<Animal>();
            this.Zookeepers = new List<Zookeeper>();
        }

        public void AddAnimal(Animal animal)
        {
            if (animal == null)
                return;

            Animals.Add(animal);
        }

        public void RemoveAnimal(string animalId)
        {
            Animal animal = Animals.Find(x => x.AnimalId == animalId);
            if (animal == null)
                return;

            foreach (var item in Zookeepers.Where(x => x.IsAssignedAnimal(animalId)))
            {
                item.UnassignedAnimal(animal);
            }

            Animals.RemoveAll(x => x == animal);
        }

        public void AddKeeper(Zookeeper keeper)
        {
            if (keeper == null)
                return;

            Zookeepers.Add(keeper);
        }
        public void AssignAnimalToKeeper(Animal animal, Zookeeper keeper)
        {
            if (animal == null || keeper == null)
                return;

            if (!Animals.Exists(x => x == animal))
                AddAnimal(animal);

            if (!Zookeepers.Exists(x => x == keeper))
                AddKeeper(keeper);

            keeper.AssignedAnimal(animal);
        }

        public List<Animal> GetAnimalsByHabitat(string habitat) => Animals.FindAll(x => x.GetHabitat().Contains(habitat));

        public List<Animal> GetAnimalsBySpecies(string Species) => Animals.FindAll(x => x.Species.Contains(Species));

        public decimal calculateTotalWeeklyCost() => Animals.Sum(x => x.CalculateWeeklyCost());

        public void DisplayAllAnimal()
        {
            Console.WriteLine($"=== {ZooName} - All Animals ===");
            foreach (var item in Animals)
            {
                Console.WriteLine(item.GetAnimalInfo());
            }
        }

        public void GetZooStatistics()
        {
            Console.WriteLine($"=== {ZooName} Statistics ===");
            Console.WriteLine($"Total Animals: {Animals.Count}");
            Console.WriteLine($"Total ZooKeepers: {Zookeepers.Count}");
            Console.WriteLine($"Habitats Represented: {Animals.GroupBy(x => x.GetHabitat()).Count()}");
            Console.WriteLine($"Total Weekly Maintenance: ${calculateTotalWeeklyCost()}");
            Console.WriteLine($"Average Animal Age: {Animals.Average(x => x.Age)} years");
        }
    }
}
