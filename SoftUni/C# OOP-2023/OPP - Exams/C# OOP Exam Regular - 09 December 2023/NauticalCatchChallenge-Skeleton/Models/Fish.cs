﻿using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;

        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name should be determined.");
                }

                name = value;
            }
        }

        public double Points
        {
            //Check hier
            get => Math.Round(points,1);
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }

                points = value;
            }
        }

        public int TimeToCatch { get; private set; }


        public override string ToString()
            => $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
    }
}
