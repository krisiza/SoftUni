using _2.VehiclesExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefualable
    {
        private const string FuelAboveTheCapacityExceptionMessage = "Cannot fit {0} fuel in the tank";
        private const string FuelNegativeNumberExceptionMessage = "Fuel must be a positive number";

        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsuptionPerKm, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsuptionPerKm = fuelConsuptionPerKm;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;

            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Fuel quantity cannot be less than zero");

                if (value > TankCapacity)
                {
                    Console.WriteLine((string.Format(FuelAboveTheCapacityExceptionMessage, value)));
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsuptionPerKm
        {
            get => fuelConsumption;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be less than or equal to zero");
                }
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => tankCapacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Tank capacity cannot be less than zero");
                }
                this.tankCapacity = value;
            }
        }

        public void Drive(double distance)
        {
            double consumption = distance * FuelConsuptionPerKm;

            if (consumption > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= consumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
                throw new Exception(FuelNegativeNumberExceptionMessage);

            if (FuelQuantity + fuel > TankCapacity)
                throw new ArgumentException(string.Format(FuelAboveTheCapacityExceptionMessage, fuel));

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
