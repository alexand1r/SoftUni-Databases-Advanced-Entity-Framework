using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class KickMemberCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            string username = inputArgs[1];

            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, username));
            }

            if (this.IsUserMemberOfTeam(username, teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, username, teamName));
            }

            if (this.IsUserCreatorOfTeam(username, teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.CommandNotAllowed);
            }

            if (AuthenticationManager.GetCurrentUser().Username == username)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "DisbandTeam"));
            }

            this.KickMemberFromTeam(teamName, username);

            return $"User {username} was kicked from {teamName}!";
        }

        private void KickMemberFromTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                team.Members.Remove(user);
                context.SaveChanges();
            }
        }
        private bool IsUserMemberOfTeam(string username, string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(
                    t => t.Name == teamName &&
                    t.Members.Any(m => m.Username == username));
            }
        }

        private bool IsUserCreatorOfTeam(string username, string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);

                return context.Teams.Any(
                    t => t.Name == teamName &&
                         t.CreatorId == user.Id);
            }
        }
    }
}
