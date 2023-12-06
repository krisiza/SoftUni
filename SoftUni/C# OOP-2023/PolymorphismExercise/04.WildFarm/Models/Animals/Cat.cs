
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double catWeightMultiplier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => catWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes
            =>new HashSet<Type> {typeof(Meat), typeof(Vegetable)};

        public override string ProduceSound()
            => "Meow";
    }
}
