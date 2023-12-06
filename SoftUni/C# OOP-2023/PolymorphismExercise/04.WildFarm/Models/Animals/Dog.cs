
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double dogWeightMultiplier = 0.4;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier => dogWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type> { typeof(Meat)};

        public override string ProduceSound()
            => "Woof!";

        public override string ToString()
           => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
