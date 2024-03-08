using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Drawing;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if(String.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size {get; private set;}

        public double Price
        {
            get => price;
            private set
            {
                if(Size == "Large")
                {
                    price = value;
                }
                else if(Size == "Middle")
                {
                    price = value * 2 / 3;
                }
                else if(Size == "Small")
                {
                    price = value * 1 / 3;
                }
            }
        }

        public override string ToString()
            => $"{Name} ({Size}) - {Price:F2} lv";
    }
}
