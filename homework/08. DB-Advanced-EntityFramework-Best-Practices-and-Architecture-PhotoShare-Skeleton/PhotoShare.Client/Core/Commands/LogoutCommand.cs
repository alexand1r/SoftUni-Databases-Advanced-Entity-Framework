using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        public string Execute()
        {
            var user = Authentication.GetCurrentUser();
            Authentication.loggedInUser = null;
            return $"User {user.Username} successfully logged out!";
        }
    }
}
