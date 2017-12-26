using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class ShowTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            return this.ShowTeam(teamName);
        }

        private string ShowTeam(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                sb.AppendLine($"{team.Name} {team.Acronym}");
                sb.AppendLine("Members:");
                foreach (User u in team.Members)
                {
                    sb.AppendLine($"--{u.Username}");
                }
            }

            return sb.ToString();
        }
    }
}
