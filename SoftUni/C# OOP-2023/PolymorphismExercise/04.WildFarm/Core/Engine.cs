using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.IO.Interfaces;
using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.Models.FoodDir.Interfaces;
using _04.WildFarm.WildFarmFactory.Interfaces;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        IWildFarmFactory animalFactory;
        IFoodFactory foodFactory;

        ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IWildFarmFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                ProcessInput(input);
            }

            foreach (var an in animals)
            {
                Console.WriteLine(an);
            }
        }
        private void ProcessInput(string input)
        {
            string[] animalsTokes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] foodTokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = null;
            try
            {
                animal = animalFactory.CreateAnimal(animalsTokes);
                animals.Add(animal);
                writer.WriteLine(animal.ProduceSound());

                IFood food = foodFactory.CreateFood(foodTokens[0], int.Parse(foodTokens[1]));
                animal.Feed(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
