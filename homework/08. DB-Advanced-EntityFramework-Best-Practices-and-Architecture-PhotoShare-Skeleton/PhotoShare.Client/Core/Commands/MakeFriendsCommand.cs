using System.Linq;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class MakeFriendsCommand
    {
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            string username1 = data[0];
            string username2 = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user1 = context.Users.SingleOrDefault(u => u.Username == username1);
                var user2 = context.Users.SingleOrDefault(u => u.Username == username2);

                if (!Authentication.CheckUser(user1))
                    throw new InvalidOperationException($"Invalid Credentials!");

                if (user1 == null)
                {
                    throw new ArgumentException($"{username1} not found!");
                }
                else if (user2 == null)
                {
                    throw new ArgumentException($"{username2} not found!");
                }
                
                if (user1.Friends.Contains(user2))
                {
                    throw new InvalidOperationException($"{username2} is already a friend to {username1}");
                }

                user1.Friends.Add(user2);
                context.SaveChanges();
            }

            return $"Friend {username2} added to {username1}";
        }
    }
}
