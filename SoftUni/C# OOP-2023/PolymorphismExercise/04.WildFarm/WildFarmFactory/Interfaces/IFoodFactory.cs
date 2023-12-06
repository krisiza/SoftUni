using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.WildFarmFactory.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
