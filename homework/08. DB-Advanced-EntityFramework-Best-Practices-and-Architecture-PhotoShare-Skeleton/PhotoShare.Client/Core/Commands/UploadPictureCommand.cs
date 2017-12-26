using System;
using System.Linq;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums.FirstOrDefault(a => a.Name == albumName);
                if (album == null) throw new ArgumentException($"Album {albumName} not found!");

                if (album.AlbumRoles
                        .FirstOrDefault(ar => ar.User == Authentication.GetCurrentUser()
                                     && ar.Role == Role.Owner) == null)
                {
                    throw new InvalidOperationException($"Invalid Credentials!");
                }

                Picture picture = new Picture
                {
                    Title = pictureTitle,
                    Path = pictureFilePath
                };
                picture.Albums.Add(album);
                album.Pictures.Add(picture);
                context.SaveChanges();
            }

            return $"Picture {pictureTitle} added to album {albumName}!";
        }
    }
}
