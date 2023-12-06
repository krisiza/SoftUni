namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            database = new Database(initialData);
        }

        [Test]
        public void TestCollectionLength()
        {
            int expectedLength = 2;

            Assert.That(database.Count, Is.EqualTo(expectedLength));
        }

        [Test]
        public void ArrayWithMoreCapacity()
        {
            //Arrange and Act
            int[] testArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Arrange
            Assert.Throws<InvalidOperationException>
                (() => { Database database = new Database(testArr); });
        }

        [Test]
        public void AddElementToFullArray()
        {
            //Arrange
            int[] testArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            //Act
            Database database = new Database(testArr);

            //Arrange
            Assert.Throws<InvalidOperationException>
                (() => { database.Add(17); }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveLastElemet()
        {
            //Act
            database.Remove();
            database.Remove();

            //Arrange
            Assert.Throws<InvalidOperationException>
                (() => { database.Remove(); }, "The collection is empty!");
        }


        [Test]
        public void FetchResturnsTheSameArray()
        {
            int[] resultArr = database.Fetch();

            //Arrange
            Assert.AreEqual(initialData, resultArr);
        }
    }
}
