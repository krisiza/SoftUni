using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Models
{
    public class Druid : BaseHero
    {
        const int power = 80;
        public Druid(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
