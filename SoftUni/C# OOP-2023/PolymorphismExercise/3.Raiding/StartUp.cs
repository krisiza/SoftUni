using _3.Raiding.Core;
using _3.Raiding.Factories;
using _3.Raiding.Factories.Interfaces;
using _3.Raiding.IO;
using _3.Raiding.IO.Interfaces;

namespace _3.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new(new Writer(), new Reader(), new HeroFactory());
            engine.Run();
        }
    }
}