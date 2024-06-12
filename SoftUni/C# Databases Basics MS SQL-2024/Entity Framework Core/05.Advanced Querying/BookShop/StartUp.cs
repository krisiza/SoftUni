namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder stringBuilder = new StringBuilder();

            bool hasParse = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObject);

            AgeRestriction ageRestriction;
            if (hasParse)
            {
                ageRestriction = (AgeRestriction)ageRestrictionObject;

                var books = context.Books
                 .Where(b => b.AgeRestriction == ageRestriction)
                 .OrderBy(b => b.Title)
                 .ToList();

                foreach (var book in books)
                {
                    stringBuilder.AppendLine(book.Title);
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                        b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                    .Where(b => b.ReleaseDate.Value.Year != year)
                    .OrderBy(b => b.BookId)
                    .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categoriesArr = input.ToLower().Split(' ');

            var books = context.Books
                      .Select(b => new
                      {
                          b.Title,
                          Category = b.BookCategories.Select(bc => new
                          {
                              bc.Category.Name,
                          }),
                      })
                    .Where(b => categoriesArr.Contains(b.Category.First().Name.ToLower()))
                    .OrderBy(b => b.Title)
                    .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Check
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder builder = new StringBuilder();

            DateTime dateTime = DateTime.Parse(date);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                builder.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price.ToString("F2")}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    Fullname = a.FirstName + " " + a.LastName
                })
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.Fullname)
                .ToList();

            foreach (var author in authors)
            {
                builder.AppendLine(author.Fullname);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .ToList();

            books.ForEach(b => { builder.AppendLine(b.Title); });

            return builder.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            var books = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorLastname = b.Author.LastName,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                })
                .Where(b => b.AuthorLastname.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            books.ForEach(b => builder.AppendLine($"{b.Title} ({b.Author})"));

            return builder.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.
                Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookCopies = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .ToList()
                .OrderByDescending(b => b.Copies) // Is quickly
                .ToList(); 

            bookCopies.ForEach(b => sb.AppendLine($"{b.AuthorName} - {b.Copies}"));
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) 
        {
            StringBuilder stringBuilder = new StringBuilder();

            var bookscategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Price * cb.Book.Copies).Sum()
                })
                .ToList()
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            bookscategory.ForEach(c => stringBuilder.AppendLine($"{c.Name} ${c.Profit.ToString("F2")}"));

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var recentbooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                })
                .ToList();

            foreach (var rb in recentbooks)
            {
                sb.AppendLine($"--{rb.CategoryName}");

                foreach (var b in rb.Books.OrderByDescending(b => b.ReleaseDate))
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.
                Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            int[] selectedBooksForDelete = context.Books
                .Where(b => b.Copies < 4200)
                .Select(b => b.BookId)
                .ToArray();

            ICollection<BookCategory> removeRelations = new HashSet<BookCategory>();

            removeRelations = context.BooksCategories
                .Where(b => selectedBooksForDelete
                .Contains(b.BookId))
                .ToArray();

            context.BooksCategories.RemoveRange(removeRelations);

            var deleteThis = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(deleteThis);

            context.SaveChanges();

            return context.SaveChanges();
        }
    }
}


