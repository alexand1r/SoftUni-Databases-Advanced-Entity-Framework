namespace _3.SalesDatabase
{
    using _3.SalesDatabase.Models;
    using System;
    public class SalesDatabase
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();
            context.Database.Initialize(true);

            //foreach (Product pr in context.Products)
            //{
            //    Console.WriteLine(pr.Name);
            //}
        }
    }
}
