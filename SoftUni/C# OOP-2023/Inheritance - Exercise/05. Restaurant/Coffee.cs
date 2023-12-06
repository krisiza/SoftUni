using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMillilieters = 50;
        private const decimal CoffePrice = 3.5M;
        public Coffee(string name, double cafeine) 
            : base(name, CoffePrice, CoffeeMillilieters)
        {
            Caffeine = cafeine;
        }

        public double Caffeine { get; set; }
    }
}
