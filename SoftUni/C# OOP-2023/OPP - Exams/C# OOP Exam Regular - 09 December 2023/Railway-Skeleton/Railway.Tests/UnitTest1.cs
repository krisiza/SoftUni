namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new("Station");
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(railwayStation);
            Assert.AreEqual("Station", railwayStation.Name);
            Assert.IsEmpty(railwayStation.DepartureTrains);
            Assert.IsEmpty(railwayStation.ArrivalTrains);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void IncorrectName(string name)
        {
            Assert.Throws<ArgumentException>(
                () => railwayStation = new(name), "Name cannot be null or empty!");
        }

        [Test]
        public void TestNewArrival()
        {
            railwayStation.NewArrivalOnBoard("DB59");

            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0,railwayStation.DepartureTrains.Count);
            Assert.IsTrue(railwayStation.ArrivalTrains.Contains("DB59"));
        }

        [Test]
        public void TestNewArrivalWithMoreValues()
        {
            railwayStation.NewArrivalOnBoard("DB59");
            railwayStation.NewArrivalOnBoard("DB50");
            railwayStation.NewArrivalOnBoard("DB51");
            railwayStation.NewArrivalOnBoard("DB52");

            Assert.AreEqual(4, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
            Assert.IsTrue(railwayStation.ArrivalTrains.Contains("DB59"));
        }

        [Test]
        public void TrainHasNotArrived()
        {
            railwayStation.NewArrivalOnBoard("DB59");
            railwayStation.NewArrivalOnBoard("DB50");
            railwayStation.NewArrivalOnBoard("DB51");
            railwayStation.NewArrivalOnBoard("DB52");

            railwayStation.DepartureTrains.Enqueue("DB52");
            railwayStation.DepartureTrains.Enqueue("DB44");

            string actual = railwayStation.TrainHasArrived("DB52");
            string expected = "There are other trains to arrive before DB52.";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrainHasArrivedSuccessfully()
        {
            railwayStation.NewArrivalOnBoard("DB59");
            railwayStation.NewArrivalOnBoard("DB50");
            railwayStation.NewArrivalOnBoard("DB51");
            railwayStation.NewArrivalOnBoard("DB52");

            railwayStation.DepartureTrains.Enqueue("DB50");
            railwayStation.DepartureTrains.Enqueue("DB44");

            string actual = railwayStation.TrainHasArrived("DB59");
            string expected = $"DB59 is on the platform and will leave in 5 minutes.";

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(3, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(3, railwayStation.DepartureTrains.Count());
            Assert.IsFalse(railwayStation.ArrivalTrains.Contains("DB59"));
            Assert.IsTrue(railwayStation.DepartureTrains.Contains("DB59"));
        }

        [Test]
        public void TrainHastLeftSuccessfully()
        {
            railwayStation.NewArrivalOnBoard("DB59");
            railwayStation.NewArrivalOnBoard("DB50");
            railwayStation.NewArrivalOnBoard("DB51");
            railwayStation.NewArrivalOnBoard("DB52");

            railwayStation.TrainHasArrived("DB59");
            railwayStation.TrainHasArrived("DB50");

            bool actual = railwayStation.TrainHasLeft("DB59");

            Assert.AreEqual(true, actual);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasNOTtLeft()
        {
            railwayStation.NewArrivalOnBoard("DB59");
            railwayStation.NewArrivalOnBoard("DB50");
            railwayStation.NewArrivalOnBoard("DB51");
            railwayStation.NewArrivalOnBoard("DB52");

            railwayStation.TrainHasArrived("DB59");
            railwayStation.TrainHasArrived("DB50");

            bool actual = railwayStation.TrainHasLeft("DB50");

            Assert.AreEqual(false, actual);
            Assert.AreEqual(2, railwayStation.DepartureTrains.Count);
        }
    }
}