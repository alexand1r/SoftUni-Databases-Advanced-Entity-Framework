using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class ImportTeamsCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<Team> teams;
            try
            {
                teams = this.GetTeamsFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddTeams(teams);

            return $"You have successufully imported {teams.Count} teams!";
        }

        private List<Team> GetTeamsFromXml(string filePath)
        {
            List<Team> teams = new List<Team>();

            XDocument teamsDoc = XDocument.Load(filePath);

            XElement teamsRoot = teamsDoc.Root;
            foreach (XElement teamElement in teamsRoot.Elements())
            {
                string name = teamElement.Element("name").Value;
                string description = teamElement.Element("description").Value;
                string acronym = teamElement.Element("acronym").Value;
                int creatorId = int.Parse(teamElement.Element("creator-id").Value);
                

                teams.Add(new Team()
                {
                    Name = name,
                    Description = description,
                    Acronym = acronym,
                    CreatorId = creatorId
                });
            }

            return teams;
        }

        private void AddTeams(List<Team> teams)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                context.Teams.AddRange(teams);
                context.SaveChanges();
            }
        }
    }
}
