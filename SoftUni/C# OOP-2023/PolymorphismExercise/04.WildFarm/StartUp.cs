using _04.WildFarm.Core;
using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.IO;
using _04.WildFarm.IO.Interfaces;
using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.Models.FoodDir.Interfaces;
using _04.WildFarm.WildFarmFactory;
using _04.WildFarm.WildFarmFactory.Interfaces;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new Reader(), new Writer(), new WildfarmFactory(), new FoodFactory());
            engine.Run();
        }
    }
}