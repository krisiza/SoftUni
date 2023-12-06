using _04.WildFarm.Models.FoodDir;
using _04.WildFarm.Models.FoodDir.Interfaces;
using _04.WildFarm.WildFarmFactory.Interfaces;


namespace _04.WildFarm.WildFarmFactory
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            return type switch
            {
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                _ => throw new ArgumentException("Invalid food type!")
            };
        }
    }
}
