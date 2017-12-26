using System.Data.Common;
using System.Linq;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ShareAlbumCommand
    {
        // ShareAlbum <album> <username> <permission>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string username = data[1];
            string permission = data[2];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);
                if (user == null) throw new ArgumentException($"User {username} not found!");

                var album = context.Albums.FirstOrDefault(a => a.Name == albumName);
                if (album == null) throw new ArgumentException($"Album {albumName} not found!");

                if (album.AlbumRoles
                        .FirstOrDefault(ar => ar.User == Authentication.GetCurrentUser()
                                     && ar.Role == Role.Owner) == null)
                {
                    throw new InvalidOperationException($"Invalid Credentials!");
                }

                if (permission != "Owner" && permission != "Viewer")
                {
                    Console.WriteLine(permission);
                    throw new ArgumentException("Permission must be either \"Owner\" or \"Viewer\"!");
                }
                var albumRole = new AlbumRole()
                {
                    Album = album,
                    User = user,
                    Role = (Role)Enum.Parse(typeof(Role), permission)
                };
                user.AlbumRoles.Add(albumRole);
                album.AlbumRoles.Add(albumRole);
                context.SaveChanges();
            }

            return $"Username {username} added to album {albumName} ({permission})";
        }
    }
}
