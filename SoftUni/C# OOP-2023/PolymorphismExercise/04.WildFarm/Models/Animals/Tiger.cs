
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    internal class Tiger : Feline
    {
        private const double tigerWeightMultiplier = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight,livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => tigerWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type> { typeof(Meat)};

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
