using _04.WildFarm.Models.FoodDir.Interfaces;


namespace _04.WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);

    }
}
