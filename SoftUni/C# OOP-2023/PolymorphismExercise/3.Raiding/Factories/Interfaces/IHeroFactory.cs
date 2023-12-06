using _3.Raiding.Models.Interfaces;

namespace _3.Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
