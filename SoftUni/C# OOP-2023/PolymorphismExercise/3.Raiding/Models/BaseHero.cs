using _3.Raiding.Models.Interfaces;

namespace _3.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }

}
