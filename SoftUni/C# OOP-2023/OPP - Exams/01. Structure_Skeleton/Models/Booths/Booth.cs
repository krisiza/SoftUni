﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
        }
        public int BoothId {get; private set;}

        public int Capacity
        {
            get => capacity;

            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu {get; private set;}

        public IRepository<ICocktail> CocktailMenu {get; private set;}

        public double CurrentBill {get; private set;}

        public double Turnover { get; private set;}

        public bool IsReserved { get; private set;}

        public void ChangeStatus()
        {
            if(IsReserved)
                IsReserved = false;
            else
                IsReserved = true;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Booth: {BoothId}");
            stringBuilder.AppendLine($"Capacity: {Capacity}");
            stringBuilder.AppendLine($"Turnover: {Turnover:F2} lv");
            stringBuilder.AppendLine("-Cocktail menu:");

            foreach(var cocktail in CocktailMenu.Models)
            {
                stringBuilder.AppendLine($"--{cocktail.ToString()}");
            }

            stringBuilder.AppendLine("-Delicacy menu:");

            foreach(var delicacy in DelicacyMenu.Models)
            {
                stringBuilder.AppendLine($"--{delicacy.ToString()}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
