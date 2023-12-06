namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new("BMW", "E90", 7.9, 100);
        }

        [Test]
        public void TestContructor()
        {
            Assert.IsNotNull(car);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestMakeWithNullAndEmptyString(string make)
        {
            Assert.Throws<ArgumentException>(()
               =>
            { Car car = new Car(make, "E90", 7.9, 100); }, "Make cannot be null or empty!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestModelWithNullAndEmptyString(string model)
        {
            Assert.Throws<ArgumentException>(()
               =>
            { Car car = new Car("BMW", model, 7.9, 100); }, "Make cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void TestConsumptionWithZeroAndNegativNumber(double consumption)
        {
            Assert.Throws<ArgumentException>(()
               =>
            { Car car = new Car("BMW", "E90", consumption, 100); }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void TestCapacityWithZeroAndNegativNumber(double capacity)
        {
            Assert.Throws<ArgumentException>(()
               =>
            { Car car = new Car("BMW", "E90", 7.0, capacity); }, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void TestFuelAmountWithNegativNumber()
        {
            Type typeClass = typeof(Car);
            FieldInfo fieldInfo = typeClass.GetField("fuelAmount", BindingFlags.NonPublic | BindingFlags.Instance);
            Car classInstance = Activator.CreateInstance(typeClass, new object[] { "BMW", "E90", 7.0, 100 }) as Car;

            Assert.Throws<ArgumentException>(()
                =>
            { fieldInfo.SetValue(fieldInfo, -10); }, "Fuel amount cannot be negative!");
           
        }

        [Test]
        public void TestFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }    

        [TestCase(45.34)]
        [TestCase(1)]
        [TestCase(99)]
        [TestCase(99.999999)]
        public void ChekFuelAfterRefuel(double fuel)
        {
            car.Refuel(fuel);

            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000000)]
        [TestCase(-334.43)]
        public void RefuelNegativeAmout(double fuel)
        {
            Assert.Throws<ArgumentException>(()
                =>
            { car.Refuel(fuel); }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(101)]
        [TestCase(100.01)]
        [TestCase(1000000)]
        [TestCase(334.43)]
        public void ChekIfFuelIsMoreThenCapacity(double fuel)
        {
            car.Refuel(fuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void CheckIfIcanDriveMoreThenMyFluel()
        {
            car.Refuel(1);

            double distance = 10000000;

            Assert.Throws<InvalidOperationException>(() 
                => { car.Drive(distance); }, "You don't have enough fuel to drive!");
        }

        [TestCase(100.23, 10)]
        [TestCase(75, 10)]
        [TestCase(56.23,45)]
        [TestCase(95.453, 23.56)]
        public void CheckIfDriveCorrectly(double fuel, double distance)
        {
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            car.Refuel(fuel);
            double expextedFuel = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            Assert.AreEqual(expextedFuel, car.FuelAmount);
        }
    }
}