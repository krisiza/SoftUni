using _3.Raiding.Factories.Interfaces;
using _3.Raiding.Models;
using _3.Raiding.Models.Interfaces;

namespace _3.Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            return type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => throw new ArgumentException("Invalid hero!"),
            };
        }
    }
}
