using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Zoo_Management_System
{
    internal class Parrot : Animal
    {
        public bool CanTalk { get; private set; }
        public List<string> Vocabulary { get; private set; }

        public Parrot(string animalId, string name, string species, int age, string healthStatus, decimal dailyFoodCost, bool canTalk)
            : base(animalId, name, species, age, healthStatus, dailyFoodCost)
        {
            this.CanTalk = canTalk;
            this.Vocabulary = new List<string>();
        }

        public override string MakeSound() => "Squawk!";

        public override string GetHabitat() => "Rainforest";

        public string Speak()
        {
            if (Vocabulary == null || Vocabulary.Count == 0)
                return MakeSound();

            Random random = new Random();
            return Vocabulary[random.Next(Vocabulary.Count)];
        }

    }
}
