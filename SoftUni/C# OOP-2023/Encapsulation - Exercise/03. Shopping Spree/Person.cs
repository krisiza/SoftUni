using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new();
        }

        public string Name
        {
            get => name;

            set
            {
                if(value == null || value == string.Empty || value == " ") 
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }


        public List<Product> BagOfProducts
        {
            get => bagOfProducts;

            set
            {
                bagOfProducts = value;
            }
        }
    }
}
