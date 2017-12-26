using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class InviteToTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];
            string username = inputArgs[1];

            if (!CommandHelper.IsTeamExisting(teamName) && !CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }

            if (this.IsInvitePending(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!this.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.SendInvite(teamName, username);

            return $"Team {teamName} invited {username}!";
        }

        private bool IsInvitePending(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations
                    .Include("Team")
                    .Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.InvitedUser.Username == username && i.IsActive);
            }
        }

        private bool IsCreatorOrPartOfTeam(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User currentUser = AuthenticationManager.GetCurrentUser();

                return context.Teams.Include("Members")
                    .Any(t => t.Name == teamName &&
                              (t.CreatorId == currentUser.Id ||
                               t.Members.Any(m => m.Username == currentUser.Username)));
            }
        }

        private void SendInvite(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                User user = context.Users.FirstOrDefault(u => u.Username == username);

                Invitation invitation = new Invitation()
                {
                    InvitedUser = user,
                    Team = team
                };

                if (team.CreatorId == user.Id)
                {
                    team.Members.Add(user);
                    invitation.IsActive = false;
                }

                context.Invitations.Add(invitation);
                context.SaveChanges();
            }
        }
    }
}
