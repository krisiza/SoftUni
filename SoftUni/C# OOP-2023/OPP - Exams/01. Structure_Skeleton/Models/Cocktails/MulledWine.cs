﻿namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double largeMulledWine = 13.50;
        public MulledWine(string name, string size) 
            : base(name, size, largeMulledWine)
        {
        }
    }
}
