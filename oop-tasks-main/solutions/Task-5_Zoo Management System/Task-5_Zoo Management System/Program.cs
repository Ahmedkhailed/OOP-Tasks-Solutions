using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_5_Zoo_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create zoo
            Zoo zoo = new Zoo("Safari World");

            // Create animals
            Lion lion = new Lion("A001", "Simba", "African Lion", 5, "Healthy", 50.00m, "Golden", 3);
            Elephant elephant = new Elephant("A002", "Dumbo", "African Elephant", 15, "Healthy", 80.00m, (float)2.5, 5000);
            Parrot parrot = new Parrot("A003", "Polly", "Macaw", 8, "Healthy", 10.00m, true);
            parrot.Vocabulary.Add("Hello");
            parrot.Vocabulary.Add("Goodbye");
            parrot.Vocabulary.Add("Pretty bird");
            Snake snake = new Snake("A004", "Kaa", "Python", 10, "Healthy", 15.00m, true, (float)4.5);
            Eagle eagle = new Eagle("A005", "Freedom", "Bald Eagle", 6, "Healthy", 20.00m, (float)2.3, 320);

            // Add animals to zoo
            zoo.AddAnimal(lion);
            zoo.AddAnimal(elephant);
            zoo.AddAnimal(parrot);
            zoo.AddAnimal(snake);
            zoo.AddAnimal(eagle);

            // Create zookeepers
            Zookeeper keeper1 = new Zookeeper("K001", "John Smith", "Mammals");
            Zookeeper keeper2 = new Zookeeper("K002", "Jane Doe", "Birds and Reptiles");

            zoo.Zookeepers.Add(keeper1);
            zoo.Zookeepers.Add(keeper2);

            // Assign animals to keepers
            zoo.AssignAnimalToKeeper(lion, keeper1);
            zoo.AssignAnimalToKeeper(elephant, keeper1);
            zoo.AssignAnimalToKeeper(parrot, keeper2);
            zoo.AssignAnimalToKeeper(snake, keeper2);
            zoo.AssignAnimalToKeeper(eagle, keeper2);

            // Display all animals
            zoo.DisplayAllAnimal();

            // Demonstrate polymorphism
            Console.WriteLine("\n=== Animal Sounds ===");
            foreach (var animal in zoo.Animals)
                Console.WriteLine(animal.Name + " says: " + animal.MakeSound());

            // Get animals by habitat
            Console.WriteLine("\n=== Savanna Animals ===");
            List<Animal> savannaAnimals = zoo.GetAnimalsByHabitat("Savanna");
            foreach (var animal in savannaAnimals)
                Console.WriteLine("- " + animal.Name + " (" + animal.Species + ")");

            // Calculate costs
            decimal weeklyCost = zoo.calculateTotalWeeklyCost();
            Console.WriteLine("\nTotal Weekly Cost: $" + weeklyCost);

            // Zookeeper work
            Console.WriteLine("\n=== Zookeeper Activities ===");
            keeper1.FeedAnimal(lion);
            keeper1.CheckHealth(elephant);
            Console.WriteLine(keeper1.Name + "'s workload: " + keeper1.GetWorkLoad() + " animals");

            // Zoo statistics
            zoo.GetZooStatistics();
        }
    }
}
