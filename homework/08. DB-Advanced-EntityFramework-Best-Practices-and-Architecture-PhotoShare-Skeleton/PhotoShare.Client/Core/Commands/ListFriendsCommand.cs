using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class ListFriendsCommand
    {
        // ListFriends <username>
        public string Execute(string[] data)
        {
            string username = data[0];
            string result = String.Empty;

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);
                if (user == null) throw new ArgumentException($"User {username} not found!");
                var friends = user.Friends;
                if (friends.Count == 0) Console.WriteLine("No friends for this user. :(");
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Friends:");
                    foreach (var u in friends)
                    {
                        sb.AppendLine($"-{u.Username}");
                    }
                    result = sb.ToString();
                }
            }

            return result;
        }
    }
}
