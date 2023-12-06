using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {
		private string model;
		private double fuelAmount;
		private double travelledDistance;
		private double fuelconsumptionPerKilometer;

        public Car(string model, double fuelAmount, double fuelConsumprionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumprionPerKilometer = fuelConsumprionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}

		public double FuelConsumprionPerKilometer
		{
			get { return fuelconsumptionPerKilometer; }
			set { fuelconsumptionPerKilometer = value; }
		}

		public double TravelledDistance
		{
			get { return travelledDistance; }
			set { travelledDistance = value; }
		}

		public void CalculteFuel(Car car, double km)
		{
			double neededFuel = FuelConsumprionPerKilometer * km;
			
			if(neededFuel <= fuelAmount) 
			{
				fuelAmount -= neededFuel;
				travelledDistance += km;
			}
			else
			{
				Console.WriteLine("Insufficient fuel for the drive");
			}
		}
	}
}
