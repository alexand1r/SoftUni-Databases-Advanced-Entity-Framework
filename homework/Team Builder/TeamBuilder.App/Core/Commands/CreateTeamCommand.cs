using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            if (inputArgs.Length != 2 && inputArgs.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(inputArgs));
            }

            User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (teamName.Length > 25)
            {
                throw new ArgumentException($"Team's name too long!");
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            string acronym = inputArgs[1];

            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            string description = inputArgs.Length == 3 ? inputArgs[2] : null;

            this.AddTeam(teamName, acronym, description, currentUser);

            return $"Team {teamName} successfully created!";
        }

        private void AddTeam(string teamName, string acronym, string description, User currentUser)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Team t = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = currentUser.Id
                };

                context.Teams.Add(t);
                context.SaveChanges();
            }
        }
    }
}
