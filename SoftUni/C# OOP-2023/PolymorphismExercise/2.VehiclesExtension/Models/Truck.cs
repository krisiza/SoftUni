
namespace Vehicles.Models
{
    internal class Truck : Vehicle
    {
        private const string FuelAboveTheCapacityExceptionMessage = "Cannot fit {0} fuel in the tank";
        private const string FuelNegativeNumberExceptionMessage = "Fuel must be a positive number";

        const double conditionerConsumption = 1.6;

        private double fuelConsuption;

        public Truck(double fuelQuantity, double fuelConsuptionPerKm, int tankCapacity) 
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {
            this.FuelConsuptionPerKm += conditionerConsumption;
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
                throw new Exception(FuelNegativeNumberExceptionMessage);

            if (FuelQuantity + fuel > TankCapacity)
                throw new ArgumentException(string.Format(FuelAboveTheCapacityExceptionMessage, fuel));

            base.Refuel(fuel * 0.95);
        }
    }
}
