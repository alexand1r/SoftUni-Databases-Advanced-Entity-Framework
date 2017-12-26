using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;

namespace PhotoShare.Client.Core
{
    public class Authentication
    {
        public static User loggedInUser;

        public Authentication()
        {
            loggedInUser = null;
        }

        public static bool isAuthenticated()
        {
            return loggedInUser != null;
        }

        public static User GetCurrentUser()
        {
            return loggedInUser;
        }

        public static bool CheckUser(User user)
        {
            return Authentication.GetCurrentUser() == user;
        }
    }
}
