using _1.Vehicles.Core;
using _1.Vehicles.Factories;
using _1.Vehicles.IO;
using _1.Vehicles.IO.Interfaces;

namespace _1.Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new Reader(), new Writer(), new VehicleFactory());
            engine.Run();
        }
    }
}