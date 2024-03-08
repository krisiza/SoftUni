using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new("KrisisFactory", 5);
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(factory);
            Assert.AreEqual("KrisisFactory", factory.Name);
            Assert.AreEqual(5, factory.Capacity);
            Assert.NotNull(factory.Supplements);
            Assert.NotNull(factory.Robots);
            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual(0, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobotSuccessfully()
        {
            Robot robot = new("Ted", 299.99, 99);
            string actual = factory.ProduceRobot("Ted", 299.99, 99);

            Assert.AreEqual($"Produced --> {robot}", actual);
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobotFail()
        {
            for(int  i = 0; i < 5; i++)
            {
                factory.ProduceRobot("Ted", 299.99, 99);
            }

            string expected = $"The factory is unable to produce more robots for this production day!";
            string actual = factory.ProduceRobot("Ted", 299.99, 99);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(5, factory.Robots.Count);
        }

        [Test]
        public void AddSupplement()
        {
            Supplement supplement = new("1", 8);

            string actual = factory.ProduceSupplement("1", 8);
            string expected = supplement.ToString();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotReturnsTrue()
        {
            Robot robot = new("aA", 100,1);
            Supplement supplement = new("1", 1);

            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotContainsSupplemet()
        {
            Robot robot = new("aA", 100, 1);
            Supplement supplement = new("1", 1);
            robot.Supplements.Add(supplement);

            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UpgradeRobotHasDifferentStandarts()
        {
            Robot robot = new("aA", 100, 2);
            Supplement supplement = new("1", 1);

            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]

        public void SellRobotWithMoreMoney()
        {
            for(int i = 0; i < 50; i += 10) 
            {
                factory.ProduceRobot($"Robot{i}", 100 + i, 10);
            }

            var robotForSale = factory.SellRobot(500);
            Assert.AreEqual(140, robotForSale.Price);
        }

        [Test]

        public void SellRobotForLess()
        {
            for (int i = 0; i < 50; i += 10)
            {
                factory.ProduceRobot($"Robot{i}", 100 + i, 10);
            }

            var robotForSale = factory.SellRobot(125);
            Assert.AreEqual(120, robotForSale.Price);
        }
    }
}