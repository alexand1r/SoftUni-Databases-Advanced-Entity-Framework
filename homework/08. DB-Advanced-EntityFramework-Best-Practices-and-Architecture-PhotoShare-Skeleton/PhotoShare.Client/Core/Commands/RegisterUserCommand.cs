﻿using System.Linq;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;

    public class RegisterUserCommand
    {
        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var usersWithSameUsername = context.Users.Any(u => u.Username == username);
                if (usersWithSameUsername)
                {
                    throw new InvalidOperationException($"Username {username} is already taken!");
                }
            }

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return "User " + user.Username + " was registered successfully!";
        }
    }
}
