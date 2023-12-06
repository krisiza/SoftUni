using _2.Vehicles.Core;
using _2.Vehicles.Factories;
using _2.Vehicles.IO;

namespace _2.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new Reader(), new Writer(), new VehicleFactory());
            engine.Run();
        }
    }
}