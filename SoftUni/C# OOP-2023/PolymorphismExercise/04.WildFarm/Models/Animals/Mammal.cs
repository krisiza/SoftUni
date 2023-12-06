﻿using _04.WildFarm.Models.Animals.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
      
    }
}
