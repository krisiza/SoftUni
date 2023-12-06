namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private readonly Person[] people = new Person[] {new Person(1, "person1"), new Person(2, "person2"),
                                                         new Person(3, "person3"), new Person(4, "person5")};

        [SetUp]
        public void Setup()
        {
            database = new Database(people);
        }

        [Test]
        public void InvalidId()
        {
            //Arrange
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(1, "sdas")); }, "There is already user with this Id!");
        }

        [Test]
        public void InvalidUsername()
        {
            //Arrange
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(5, "person1")); }, "There is already user with this username!");
        }

        [Test]
        public void RemoveLastElemet()
        {
            //Act
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();

            //Arrange
            Assert.Throws<InvalidOperationException>
                (() => { database.Remove(); });
        }

        [Test]
        public void UserNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            { database.FindByUsername("fsfsf"); }, "No user is present by this username!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyUsername(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            { database.FindByUsername(name); }, "Username parameter is null!");
        }

        [Test]
        public void FoundPersonWithUsername()
        {
            //Act
            Person foundPerson = database.FindByUsername("person1");

            //Arrange
            Assert.IsTrue(foundPerson is Person);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void IdShouldBePositiveNumber(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            { database.FindById(id); }, "Id should be a positive number!");
        }

        [Test]
        public void IdNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            { database.FindById(36524736); }, "No user is present by this ID!");
        }

        [Test]
        public void FoundPersonWithID()
        {
            //Act
            Person foundPerson = database.FindById(1);

            //Arrange
            Assert.IsTrue(foundPerson is Person);
        }

        [Test]
        public void RangeArrayWith17Elements()
        {
            //Arrange
            Person[] testArr = new Person[] {new Person(1, "person1"), new Person(2, "person2"),
                                             new Person(3, "person3"), new Person(4, "person4"),
                                             new Person(5, "person5"), new Person(6, "person6"),
                                             new Person(7, "person7"), new Person(8, "person8"),
                                             new Person(9, "person9"), new Person(10, "person10"),
                                             new Person(11, "person11"), new Person(12, "person12"),
                                             new Person(13, "person13"), new Person(14, "person14"),
                                             new Person(15, "person15"), new Person(16, "person16"),
                                             new Person(17, "person17")};


            Assert.Throws<ArgumentException>(() => { Database database = new(testArr); }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void CheckLength()
        {
            int expectedLength = 4;

            Assert.That(database.Count, Is.EqualTo(expectedLength));
        }

        [Test]
        public void AddElementToFullArray()
        {
            //Arrange
            Person[] testArr = new Person[] {new Person(1, "person1"), new Person(2, "person2"),
                                             new Person(3, "person3"), new Person(4, "person4"),
                                             new Person(5, "person5"), new Person(6, "person6"),
                                             new Person(7, "person7"), new Person(8, "person8"),
                                             new Person(9, "person9"), new Person(10, "person10"),
                                             new Person(11, "person11"), new Person(12, "person12"),
                                             new Person(13, "person13"), new Person(14, "person14"),
                                             new Person(15, "person15"), new Person(16, "person16") };

            //Act
            Database database = new Database(testArr);

            //Arrange
            Assert.Throws<InvalidOperationException>
                (() => { database.Add(new Person(17, "person17")); }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddPersonWithTheSameUsername()
        {
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(20, "person1")); }, "There is already user with this username!");
        }

        [Test]
        public void AddPersonWithTheSameID()
        {
            Assert.Throws<InvalidOperationException>(() => { database.Add(new Person(1, "person100")); }, "There is already user with this Id!");
        }


        [Test]
        public void AddNewPersonAndFindHimWithUsername()
        {
            Person testPerson = new(2731, "testPerson");

            Database database = new Database(testPerson);

            Assert.IsTrue(database.FindByUsername("testPerson") is Person);
        }

        [Test]
        public void AddNewPersonAndFindHimWithId()
        {
            Person testPerson = new(2731, "testPerson");

            Database database = new Database(testPerson);

            Assert.IsTrue(database.FindById(2731) is Person);
        }
    }
}