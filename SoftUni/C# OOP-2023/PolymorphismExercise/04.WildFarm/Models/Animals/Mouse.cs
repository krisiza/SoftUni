
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double mouseWeightMultiplier = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier => mouseWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit)};

        public override string ProduceSound()
            => "Squeak";

        public override string ToString()
           => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
