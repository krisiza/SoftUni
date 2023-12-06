using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Topping
    {
		private string type;

		private double weight;

		public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
		{
			get =>type;

			private set
			{
				string temp = value.ToLower();

				if (temp == "meat" || temp == "veggies" || temp == "cheese" || temp == "sauce")
				{
					type = value;
				}
				else
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}
			}
		}

		public double Weight
		{
			get => weight;

			private set 
			{ 
				if(value < 1 || value > 50) 
				{
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

				weight = value; 
			}
		}

        public double ToppingCalories => CalculateCalories(Type, Weight);

        private double CalculateCalories(string type, double weight)
        {
            double modifier = 0;

			if (type.ToLower() == "meat")
				modifier = 1.2;
			else if (type.ToLower() == "veggies")
				modifier = 0.8;
			else if (type.ToLower() == "cheese")
				modifier = 1.1;
			else
				modifier = 0.9;


            return (2 * weight) * modifier;
        }

    }
}
