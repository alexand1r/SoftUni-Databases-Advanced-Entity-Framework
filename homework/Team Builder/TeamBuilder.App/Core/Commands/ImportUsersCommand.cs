using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class ImportUsersCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<User> users;
            try
            {
                users = this.GetUsersFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddUsers(users);

            return $"You have successufully imported {users.Count} users!";
        }

        private List<User> GetUsersFromXml(string filePath)
        {
            List<User> users = new List<User>();

            XDocument usersDoc = XDocument.Load(filePath);

            XElement usersRoot = usersDoc.Root;
            foreach (XElement userElement in usersRoot.Elements())
            {
                string username = userElement.Element("username").Value;
                string password = userElement.Element("password").Value;
                string firstName = userElement.Element("first-name").Value;
                string lastName = userElement.Element("last-name").Value;
                int age = int.Parse(userElement.Element("age").Value);
                Gender gender;
                bool isGenderValid = Enum.TryParse(userElement.Element("gender").Value, true, out gender);

                users.Add(new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                });
            }

            return users;
        }

        private void AddUsers(List<User> users)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
