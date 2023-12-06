
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Animals.Interfaces;

namespace _04.WildFarm.WildFarmFactory.Interfaces
{
    public interface IWildFarmFactory
    {
        IAnimal CreateAnimal(string[] animalTokens);
    }
}
