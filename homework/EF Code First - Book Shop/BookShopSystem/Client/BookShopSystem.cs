using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using BookShopSystem.Data;
using BookShopSystem.Models;
using EntityFramework.Extensions;

namespace BookShopSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class BookShopSystem
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            //context.Database.Initialize(true);

            //// 1. Books Titles by Age Restriction
            // BooksByAgeRestriction(context);

            //// 2. Golden Books
            //PrintGoldenBooks(context);

            //// 3. Books by Price
            //BooksByPrice(context);

            //// 4. Not Released Books
            //NotReleasedBooks(context);

            //// 5. Book Titles by Category
            //TitlesByCategory(context);

            //// 6. Books Released Before Date
            //BooksBeforeDate(context);

            //// 7. Authors Search
            //AuthorsSearch(context);

            //// 8. Books Search
            //BooksSearch(context);

            //// 9. Book Titles Search
            //BookTitleSearch(context);

            //// 10. Count Books
            //CountBooks(context);

            //// 11. Total Book Copies
            //TotalBookCopies(context);

            //// 12. Find Profit
            //FindProfit(context);

            //// 13. Most Recent Books
            //MostRecentBooks(context);

            //// 14. Increase Book Copies
            //IncreaseBookCopies(context);

            //// 15. Remove Books
            //RemoveBooks(context);

            //// 16. Stored Procedure
            //StoredProcedure(context);
        }

        private static void StoredProcedure(BookShopContext context)
        {
            string[] data = Console.ReadLine().Split(' ');
            var count = context.Database
                .SqlQuery<int>("EXEC dbo.usp_GetBooksCountByAuthor {0}, {1}", data[0], data[1]).First();
            Console.WriteLine(count);
        }

        private static void RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200);
            Console.WriteLine(books.Count());
            books.Delete();
            context.SaveChanges();
        }

        private static void IncreaseBookCopies(BookShopContext context)
        {
            var books = context.Books
                                .Where(b => b.ReleaseDate > new DateTime(2013, 6, 6));
            foreach (Book b in books)
            {
                b.Copies += 44;
            }
            context.SaveChanges();
            Console.WriteLine(books.Count() * 44);
        }

        private static void MostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.OrderByDescending(c => c.Books.Count).ToList();
            foreach (Category c in categories)
            {
                Console.WriteLine($"--{c.Name}: {c.Books.Count} books");
                var books = c.Books
                    .OrderByDescending(b => b.ReleaseDate)
                    .ThenBy(b => b.Title).Take(3).ToList();
                foreach (Book b in books)
                {
                    Console.WriteLine($"{b.Title} ({b.ReleaseDate})");
                }
            }
        }

        private static void FindProfit(BookShopContext context)
        {
            Dictionary<string, decimal> categoriesWithTotalProfit = new Dictionary<string, decimal>();
            foreach (Category c in context.Categories)
            {
                if (!categoriesWithTotalProfit.ContainsKey(c.Name))
                {
                    categoriesWithTotalProfit.Add(c.Name, 0);
                    var profit = 0M;
                    foreach (Book b in c.Books)
                    {
                        profit += b.Copies * b.Price;
                    }
                    categoriesWithTotalProfit[c.Name] = profit;
                }
            }
            var list = categoriesWithTotalProfit.OrderByDescending(c => c.Value).ThenBy(c => c.Key).ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} - ${item.Value}");
            }
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var authors = context.Authors.OrderByDescending(a => a.Books.Sum(b => b.Copies)).ToList();
            foreach (Author a in authors)
            {
                Console.WriteLine(
                    $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}");
            }
        }

        private static void CountBooks(BookShopContext context)
        {
            int count = int.Parse(Console.ReadLine());
            var books = context.Books.Where(b => b.Title.Length > count).ToList();
            Console.WriteLine(books.Count);
        }

        private static void BookTitleSearch(BookShopContext context)
        {
            string input = Console.ReadLine();
            var authors = context.Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .ToList();
            List<Book> books = new List<Book>();
            foreach (Author a in authors)
            {
                foreach (Book b in a.Books.OrderBy(b => b.Id))
                {
                    books.Add(b);
                }
            }
            foreach (Book b in books.OrderBy(b => b.Id))
            {
                Console.WriteLine($"{b.Title} ({b.Author.FirstName} {b.Author.LastName})");
            }
        }

        private static void BooksSearch(BookShopContext context)
        {
            string input = Console.ReadLine();
            var books = context.Books
                .Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .ToList();
            foreach (Book b in books)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void AuthorsSearch(BookShopContext context)
        {
            string input = Console.ReadLine();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .ToList();
            foreach (Author a in authors)
            {
                Console.WriteLine(a.FirstName + ' ' + a.LastName);
            }
        }

        private static void BooksBeforeDate(BookShopContext context)
        {
            string[] data = Console.ReadLine().Split('-').ToArray();
            DateTime givenDate =
                new DateTime(
                    int.Parse(data[2]),
                    int.Parse(data[1]),
                    int.Parse(data[0]));
            var books = context.Books
                .Where(b => b.ReleaseDate < givenDate).ToList();
            foreach (Book b in books)
            {
                Console.WriteLine($"{b.Title} - {b.Edition} - {b.Price}");
            }
        }

        private static void TitlesByCategory(BookShopContext context)
        {
            string[] data = Console.ReadLine().ToLower().Split(' ').ToArray();
            foreach (Book b in context.Books.OrderBy(b => b.Id))
            {
                if (b.Categories.Any(c => data.Contains(c.Name.ToLower())))
                {
                    Console.WriteLine(b.Title);
                }
            }
        }

        private static void NotReleasedBooks(BookShopContext context)
        {
            int year = int.Parse(Console.ReadLine());
            var books = context.Books
                .Where(b => b.ReleaseDate > new DateTime(year, 12, 31)
                    || b.ReleaseDate < new DateTime(year, 1, 1))
                .OrderBy(b => b.Id)
                .Select(b => b.Title)
                .ToList();
            foreach (string title in books)
            {
                Console.WriteLine(title);
            }
        }

        private static void BooksByPrice(BookShopContext context)
        {
            var books = context.Books
                            .Where(b => b.Price < 5 || b.Price > 40)
                            .OrderBy(b => b.Id)
                            .ToList();
            foreach (Book b in books)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void PrintGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Edition == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();
            foreach (string t in books)
            {
                Console.WriteLine(t);
            }
        }

        private static void BooksByAgeRestriction(BookShopContext context)
        {
            string ageRestrictionString = Console.ReadLine();
            var books = context.Books.Where(b => b.AgeRestriction.ToString() == ageRestrictionString);
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
