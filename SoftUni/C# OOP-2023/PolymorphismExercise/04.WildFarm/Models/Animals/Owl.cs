
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double owlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => owlWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type> {typeof(Meat)};

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
