
using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double henWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => henWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type> { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) };

        public override string ProduceSound()
            => "Cluck";
    }
}
