namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Tests
    {
        private UniversityLibrary universityLibrary;

        private List<TextBook> textBooks = new List<TextBook>()
        {
         new TextBook("The Notebook", "Nicholas Sparks", "Roman"),
         new TextBook("The Future", "Naomi Alderman", "Fantasy"),
         new TextBook("The Square", "Celia Waldens", "Horror"),
         new TextBook("A December To Rememberk", "Jenny Baylis", "Roman")
        };

        [SetUp]
        public void Setup()
        {
            universityLibrary = new UniversityLibrary();
        }

        [Test]
        public void TestConstruct()
        {
            Assert.AreEqual(universityLibrary.Catalogue, new List<TextBook>());
            Assert.NotNull(universityLibrary);
        }

        [Test]
        public void TestIAddMethod()
        {
            universityLibrary.AddTextBookToLibrary(new TextBook("The Square", "Celia Waldens", "Horror"));
            
            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void TestAddMethodWithList()
        {
            foreach (TextBook book in textBooks) 
            {
                universityLibrary.AddTextBookToLibrary(book);
            }

            TextBook textBook = universityLibrary.Catalogue.FirstOrDefault(u => u.Title == "The Notebook");

            Assert.AreEqual(textBooks.Count, universityLibrary.Catalogue.Count);
            Assert.AreEqual(textBooks, universityLibrary.Catalogue);
            Assert.NotNull(textBook);
        }

        [Test]
        public void TestInventoryNumber()
        {
            universityLibrary.AddTextBookToLibrary(new TextBook("The Square2", "Celia Waldens", "Horror"));

            TextBook textBook = universityLibrary.Catalogue.FirstOrDefault(c => c.Title == "The Square2");

            Assert.AreEqual(1, textBook.InventoryNumber);
        }

        [Test]
        public void TestAddTextBookToLibraryString()
        {
            TextBook textBook = new TextBook("The Square2", "Celia Waldens", "Horror");
            string test = universityLibrary.AddTextBookToLibrary(textBook);

            Assert.That(test == textBook.ToString());
        }

        [TestCase("John", 1)]
        [TestCase("Marry", 2)]
        [TestCase("Ivon", 3)]

        public void TestLoanTextBookStringWithLoaned(string name, int inventoryNumber)
        {
            foreach (TextBook book in textBooks)
            {
                universityLibrary.AddTextBookToLibrary(book);
            }

            TextBook textBook = universityLibrary.Catalogue.FirstOrDefault(c => c.InventoryNumber == inventoryNumber);

            string test = universityLibrary.LoanTextBook(inventoryNumber, name);

            string expexted = $"{textBook.Title} loaned to {name}.";

            Assert.That(test == expexted);
        }

        [TestCase("John", 1)]
        [TestCase("Marry", 2)]
        [TestCase("Ivon", 3)]
        [TestCase("Nick", 4)]

        public void TestLoanTextBookStringWithAlreadyLoaned(string name, int inventoryNumber)
        {
            foreach (TextBook book in textBooks)
            {
                universityLibrary.AddTextBookToLibrary(book);
                universityLibrary.LoanTextBook(book.InventoryNumber, name);
            }

            TextBook textBook = universityLibrary.Catalogue.FirstOrDefault(c => c.InventoryNumber == inventoryNumber);

            string test = universityLibrary.LoanTextBook(inventoryNumber, name);

            string expexted = $"{name} still hasn't returned {textBook.Title}!";

            Assert.That(test == expexted);
        }

        [Test]
        public void SearchBookWithInventoryNumber()
        {
            foreach (TextBook book in textBooks)
            {
                universityLibrary.AddTextBookToLibrary(book);
            }

            TextBook textBook = universityLibrary.Catalogue.FirstOrDefault(c => c.InventoryNumber == 1);

            Assert.IsNotNull(textBook); 
        }

        [TestCase("John", 1)]
        [TestCase("Marry", 2)]
        [TestCase("Ivon", 3)]
        [TestCase("Nick", 4)]

        public void TestReturnTextBookHolderIsNull(string name, int inventoryNumber)
        {
            foreach (TextBook book in textBooks)
            {
                universityLibrary.AddTextBookToLibrary(book);
                universityLibrary.LoanTextBook(book.InventoryNumber, name);
            }

            TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber == inventoryNumber);

            universityLibrary.ReturnTextBook(inventoryNumber);

            Assert.That(string.Empty == textBook.Holder);
        }

        [TestCase("John", 1)]
        [TestCase("Marry", 2)]
        [TestCase("Ivon", 3)]
        [TestCase("Nick", 4)]
        public void TestReturnTextBookString(string name, int inventoryNumber)
        {
            foreach (TextBook book in textBooks)
            {
                universityLibrary.AddTextBookToLibrary(book);
                universityLibrary.LoanTextBook(book.InventoryNumber, name);
            }

            TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber == inventoryNumber);

            string test = universityLibrary.ReturnTextBook(inventoryNumber);

            Assert.That($"{textBook.Title} is returned to the library." == test);
        }
    }
}