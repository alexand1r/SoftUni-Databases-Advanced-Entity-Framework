using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginUserCommand
    {
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Username == username 
                        && u.Password == password);

                if (user == null) throw new ArgumentException($"Invalid username or password!");

                Authentication.loggedInUser = user;
            }

            return $"User {username} successfully logged in!";
        }
    }
}
