﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        public FreeDiver(string name) 
            : base(name,120)
        {
        }

        //Not Sure
        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        // *
        public override void RenewOxy()
        {
            this.OxygenLevel = 120;
        }
    }
}
