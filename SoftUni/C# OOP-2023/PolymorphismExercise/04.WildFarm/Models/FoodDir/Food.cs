using _04.WildFarm.Models.FoodDir.Interfaces;

namespace _04.WildFarm.Models.FoodDir
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
