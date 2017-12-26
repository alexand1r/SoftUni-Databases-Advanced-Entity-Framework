using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;
using BookShopSytem.Models;

namespace BookShopSystem.Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();

            //// 1. Books Titles by Age Restriction
            // BooksByAgeRestriction(context);

            //// 2. Golden Books
            // PrintGoldenBooks(context);

            //// 3. Books by Price
            var books = context.Books
                .Where(b => b.Price < 5 && b.Price > 40)
                .OrderBy(b => b.Id)
                .Select(b => b.Title)
                .ToList();
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }

        private static void PrintGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();
            foreach (string t in books)
            {
                Console.WriteLine(t);
            }
        }

        private static void BooksByAgeRestriction (BookShopContext context)
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
