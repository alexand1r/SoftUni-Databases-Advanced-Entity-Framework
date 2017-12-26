using System.Linq;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class AddTagToCommand 
    {
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string album = data[0];
            string tag = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var albumExists = context.Albums.FirstOrDefault(a => a.Name == album);

                var tagExists = context.Tags.FirstOrDefault(t => t.Name == tag);
                if (tagExists == null || albumExists == null)
                {
                    throw new ArgumentException($"Either tag or album do not exist!");
                }

                if (albumExists.AlbumRoles
                       .FirstOrDefault(ar => ar.User == Authentication.GetCurrentUser()
                                    && ar.Role == Role.Owner) == null)
                {
                    throw new InvalidOperationException($"Invalid Credentials!");
                }

                albumExists.Tags.Add(tagExists);
                context.SaveChanges();
            }

            return $"Tag {tag} added to {album}!";
        }
    }
}
