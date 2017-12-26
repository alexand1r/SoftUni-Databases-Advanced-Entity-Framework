using System.ComponentModel;
using System.Linq;
using PhotoShare.Models.Validation;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string user = data[0];
            string property = data[1];
            string value = data[2];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var userToModify = context.Users.FirstOrDefault(u => u.Username == user);

                if (!Authentication.CheckUser(userToModify))
                    throw new InvalidOperationException($"Invalid Credentials!");

                if (userToModify == null)
                {
                    throw new ArgumentException($"User {user} not found!");
                }

                //var propertyInfo = context.Users.GetType().GetProperty(property);
                //var propertyType = propertyInfo.PropertyType;
                //if (propertyType != value.GetType())
                //{
                //    throw new ArgumentException($"Value {value} not valid.");
                //}

                switch (property)
                {
                    case "Password":
                        userToModify.Password = value;
                        break;
                    case "BornTown":
                        var bornTown = context.Towns.FirstOrDefault(t => t.Name == value);
                        if (bornTown == null)
                        {
                            throw new ArgumentException($"Town {value} not found!");
                        }
                        userToModify.BornTown = bornTown;
                        break;
                    case "CurrentTown":
                        var currentTown = context.Towns.FirstOrDefault(t => t.Name == value);
                        if (currentTown == null)
                        {
                            throw new ArgumentException($"Town {value} not found!");
                        }
                        userToModify.CurrentTown = currentTown;
                        break;
                    default:
                        throw new ArgumentException($"Property {property} not supported!");
                }

                context.SaveChanges();
            }
            return $"User {user} {property} is {value}.";
        }
    }
}
