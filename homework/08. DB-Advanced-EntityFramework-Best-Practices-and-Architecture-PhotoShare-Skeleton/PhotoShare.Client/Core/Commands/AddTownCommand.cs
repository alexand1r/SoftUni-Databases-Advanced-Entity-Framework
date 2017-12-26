using System;
using System.Linq;

namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var townsWithSameName = context.Towns.Any(t => t.Name == townName);
                if (townsWithSameName)
                {
                    throw new InvalidOperationException($"Town {townName} is already added!");
                }

                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();

                return townName + " was added to database!";
            }
        }
    }
}
