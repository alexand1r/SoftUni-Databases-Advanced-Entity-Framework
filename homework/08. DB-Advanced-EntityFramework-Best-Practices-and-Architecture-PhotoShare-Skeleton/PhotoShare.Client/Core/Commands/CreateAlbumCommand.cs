using System.Collections.Generic;
using System.Linq;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).ToArray();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (!Authentication.CheckUser(user))
                    throw new InvalidOperationException($"Invalid Credentials!");

                if (user == null)
                {
                    throw new InvalidOperationException($"User with {username} was not found!");
                }

                var albumExists = context.Albums.FirstOrDefault(a => a.Name == albumTitle);
                if (albumExists != null)
                {
                    throw new ArgumentException($"Album {albumTitle} exists!");
                }

                if (!Enum.IsDefined(typeof(Color), bgColor))
                {
                    throw new ArgumentException($"Color {bgColor} not found!");
                }

                List<Tag> albumTags = new List<Tag>();
                foreach (string tag in tags)
                {
                    var check = context.Tags.FirstOrDefault(t => t.Name == tag);
                    albumTags.Add(check);
                    if (check == null)
                    {
                        throw new ArgumentException($"Invalid tags!");
                    }
                }

                Album album = new Album
                {
                    Name = albumTitle,
                    BackgroundColor = (Color)Enum.Parse(typeof(Color), bgColor),
                    Tags = albumTags
                };
                user.AlbumRoles.Add(new AlbumRole
                {
                    User = user,
                    Album = album,
                    Role = Role.Owner
                });
                context.SaveChanges();
            }

            return $"Album {albumTitle} successfully created!";
        }
    }
}
