using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value == string.Empty || value == null || value == " " || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get => dough;

            set
            {
                dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get => toppings;

            private set
            {
                toppings = value;
            }
        }

        public double TotalCalories => Dough.DoughCalories + Toppings.Sum(x => x.ToppingCalories);

        public void AddTopping(List<Topping> toppings)
        {
            if(toppings == null || toppings.Count < 0 || toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            foreach (var topping in toppings)
            {
                Toppings.Add(topping);
            }
        }

    }
}
