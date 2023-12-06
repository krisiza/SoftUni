using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Models
{
    public class Warrior : BaseHero
    {
        const int power = 100;
        public Warrior(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
