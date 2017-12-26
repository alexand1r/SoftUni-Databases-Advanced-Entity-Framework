﻿using System;
using System.Linq;

namespace PhotoShare.Client.Core.Commands
{
    using Models;

    using Utilities;

    public class AddTagCommand
    {
        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tag = data[0].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var tagExists = context.Tags.FirstOrDefault(t => t.Name == tag);
                if (tagExists != null)
                {
                    throw new ArgumentException($"Tag {tag} exists!");
                }

                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return tag + " was added successfully to database!";
        }
    }
}
