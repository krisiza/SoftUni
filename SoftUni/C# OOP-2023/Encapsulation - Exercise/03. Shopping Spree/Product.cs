using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Product
    {
		private string name;

		private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
		{
			get => name;

			set 
			{
                if (value == null || value == string.Empty || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value; 
			}
		}
		public decimal Cost
		{
			get => cost;

			set 
			{
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                cost = value; 
			}
		}

        public override string ToString() => Name;
	}
}
