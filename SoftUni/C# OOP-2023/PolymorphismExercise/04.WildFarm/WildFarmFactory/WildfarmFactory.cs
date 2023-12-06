using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.WildFarmFactory.Interfaces;

namespace _04.WildFarm.WildFarmFactory
{
    public class WildfarmFactory : IWildFarmFactory
    {
        public IAnimal CreateAnimal(string[] animalTokens)
        {
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]); 

            switch (type) 
            {
                case "Owl":
                    return new Owl(name, weight, double.Parse(animalTokens[3]));
                case "Hen":
                    return new Hen(name, weight, double.Parse(animalTokens[3]));
                case "Cat":
                    return new Cat(name, weight, animalTokens[3], animalTokens[4]);
                case "Tiger":
                    return new Tiger(name, weight, animalTokens[3], animalTokens[4]);
                case "Dog":
                    return new Dog(name, weight, animalTokens[3]);
                case "Mouse":
                    return new Mouse(name, weight, animalTokens[3]);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
