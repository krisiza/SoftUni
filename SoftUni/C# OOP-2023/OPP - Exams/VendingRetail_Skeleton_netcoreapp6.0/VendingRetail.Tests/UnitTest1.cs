using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private Dictionary<string, double> drinks = new()
        {
            { "Capiccino", 2.3},
            { "Coffee", 0.4 },
            { "LateMacciato", 3.2 },
            { "Chocholade", 1.9 },
            { "Tee", 0.7 }
        };

        private CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new(200, 6);
        }

        [Test]
        public void Test_Constructor()
        {
            coffeeMat = new(200, 6);
            Assert.AreEqual(200, coffeeMat.WaterCapacity);
            Assert.AreEqual(6, coffeeMat.ButtonsCount);
            Assert.IsNotNull(coffeeMat);
        }

        [Test]
        public void FillWaterMethod_Success()
        {
            coffeeMat = new(200, 6);
            string result = coffeeMat.FillWaterTank();
            string expected = $"Water tank is filled with 200ml";

            Assert.AreEqual(expected,result);
        }

        [Test]
        public void FillWaterMethod_Fail()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();
            string expected = $"Water tank is already full!";
            string result = coffeeMat.FillWaterTank();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FillWaterMethod_AfterBuyDrink()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();

            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            coffeeMat.BuyDrink("Coffee");

            string expected = $"Water tank is filled with 80ml";
            string result = coffeeMat.FillWaterTank();

            Assert.True(expected == result);
        }

        [Test]
        public void AddDrink_Success()
        {
            coffeeMat = new(200, 6);
            bool result = coffeeMat.AddDrink("newDrink", 0.4);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddDrink_SameName_Fail()
        {
            coffeeMat = new(200, 6);
            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            bool result = coffeeMat.AddDrink("Coffee", 0.4);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddDrink_NoMoreButtons_Fail()
        {
            coffeeMat = new(200, 6);
            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            coffeeMat.AddDrink("1", 0.4);
            bool result = coffeeMat.AddDrink("2", 0.4);

            Assert.IsFalse(result);
        }

        [Test]
        public void BuyDrink_OutOfWater_Fail()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();

            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Coffee");

            string result = coffeeMat.BuyDrink("Coffee");
            string expected = $"CoffeeMat is out of water!";

            Assert.True(result == expected);
        }
        [Test]
        public void BuyDrink_OutOfWater2_Fail()
        {
            coffeeMat = new(200, 6);
            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }


            string result = coffeeMat.BuyDrink("Coffee");
            string expected = $"CoffeeMat is out of water!";

            Assert.IsTrue(result == expected);
        }

        [Test]
        public void BuyDrink_CheckIncome_CheckString_Success()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();

            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            string result = coffeeMat.BuyDrink("Coffee");
            string expected = $"Your bill is 0,40$";

            string result2 = coffeeMat.FillWaterTank();

            Assert.AreEqual(0.4, coffeeMat.Income);
            Assert.AreEqual(result, expected);
            Assert.AreEqual(result2,$"Water tank is filled with 80ml");
        }

        [Test]
        public void BuyDrink_NotAvailable_Fail()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();

            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            string result = coffeeMat.BuyDrink("5");
            string expected = $"5 is not available!";

            Assert.AreEqual(result,expected);
        }

        [Test]
        public void CollctedInComeCheck_0()
        {
            coffeeMat = new(200, 6);
            double result = coffeeMat.CollectIncome();

            Assert.AreEqual(0, result);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void CollectedIncome_IncomeMoreThan0_Success()
        {
            coffeeMat = new(200, 6);
            coffeeMat.FillWaterTank();

            foreach (var drink in drinks)
            {
                coffeeMat.AddDrink(drink.Key, drink.Value);
            }

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Tee");
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("Chocholade");
            coffeeMat.BuyDrink("Capiccino");
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("LateMacciato");
   

            double result = coffeeMat.CollectIncome();

            Assert.AreEqual(8.5, result);
            Assert.AreEqual(0, coffeeMat.Income);
        }
    }
}