using _2.Vehicles.Models.Interfaces;

namespace _2.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsuption, double tankCpacity, double increasedConsumption)
        {
            TankCapacity = tankCpacity;
            FuelConsuption = fuelConsuption;
            this.increasedConsumption = increasedConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;

            private set
            {
                if (value <= 0)
                {
                    fuelQuantity = 0;
                    Console.WriteLine($"Fuel must be a positive number");
                }

                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                }
                else
                    fuelQuantity = value;
            }
        }

        public double FuelConsuption { get; private set; }

        public double TankCapacity { get; private set; }


        public virtual string Drive(double distance)
        {
            double consumption = FuelConsuption + increasedConsumption;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= consumption * distance;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            if (FuelQuantity < distance * FuelConsuption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= FuelConsuption * distance;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel;
        }

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
