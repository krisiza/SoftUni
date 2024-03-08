using NUnit.Framework;
using System;
using System.Reflection.Emit;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            shop = new(5);
        }

        [Test]
        public void ConstructorBuilder_Test()
        {
            Assert.IsNotNull(shop);
            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void NegativeCapacity_Test() 
        {
            Assert.Throws<ArgumentException>(
                () => shop = new(-1), "Invalid capacity."); 
        }

        [Test]
        public void AddAlreadyExistingPhone()
        {
            Smartphone smartphone = new("iphone15", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>( 
                () => shop.Add(new Smartphone("iphone15", 50)), $"The phone model {smartphone.ModelName} already exist.");
        }

        [Test]
        public void AddPhoneWhenNoMoreCapacity()
        {
            for(int i = 1; i <= 5; i++) 
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Samsung", 150)), "The shop is full.");

            Assert.AreEqual(5, shop.Count);
        }

        [Test]
        public void AddSuccessfully()
        {
            shop.Add(new($"Iphone15", 100));

            Assert.AreEqual (1, shop.Count);
        }

        [Test]
        public void RemoveNotExistingPhone()
        {
            for (int i = 1; i <= 5; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            Assert.Throws<InvalidOperationException>(
                () => shop.Remove("Samsung"), $"The phone model Samsung doesn't exist.");

            Assert.AreEqual(5, shop.Count);
        }

        [Test]
        public void RemoveExistingPhone()
        {
            for (int i = 1; i <= 5; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            shop.Remove("Iphone3");

            Assert.AreEqual(4, shop.Count);
        }

        [Test]
        public void TestNotExistingPhone()
        {
            for (int i = 1; i <= 5; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Samsung", 100), $"The phone model Samsung doesn't exist.");
        }

        [Test]
        public void TestPhoneWithHugeBatteryUsage()
        {
            for (int i = 1; i <= 5; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Iphone4", 110), $"The phone model Iphone4 is low on batery.");
        }

        [Test]
        public void TestPhoneSuccessfully()
        {
            Smartphone smartphone = new("Iphone15", 104);
            shop.Add(smartphone);

            for (int i = 1; i <= 4; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            shop.TestPhone("Iphone15", 10);

            Assert.AreEqual(94, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargeNotExistingPhone()
        {
            for (int i = 1; i <= 5; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            Assert.Throws<InvalidOperationException>(
                () => shop.ChargePhone("Samsung"), $"The phone model Samsung doesn't exist.");
        }

        [Test]
        public void ChargePhoneSuccessfully()
        {
            Smartphone smartphone = new("Iphone15", 104);
            shop.Add(smartphone);

            for (int i = 1; i <= 4; i++)
            {
                shop.Add(new($"Iphone{i}", 100 + i));
            }

            shop.TestPhone("Iphone15", 10);
            shop.TestPhone("Iphone15", 10);
            shop.ChargePhone("Iphone15");

            Assert.AreEqual(104, smartphone.CurrentBateryCharge);
        }
    }
}