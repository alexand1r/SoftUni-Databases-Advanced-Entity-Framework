using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using PhotoShare.Client.Core.Commands;

namespace PhotoShare.Client.Core
{
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string cmd = commandParameters[0];
            string[] parameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;
            switch (cmd)
            {
                case "RegisterUser":
                    CheckIfAuth();
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(parameters);
                    break;
                case "AddTown":
                    CheckIfNotAuth();
                    AddTownCommand addTown = new AddTownCommand();
                    result = addTown.Execute(parameters);
                    break;
                case "ModifyUser":
                    CheckIfNotAuth();
                    ModifyUserCommand modifyUser = new ModifyUserCommand();
                    result = modifyUser.Execute(parameters);
                    break;
                case "DeleteUser":
                    CheckIfNotAuth();
                    DeleteUser deleteUser = new DeleteUser();
                    result = deleteUser.Execute(parameters);
                    break;
                case "AddTag":
                    CheckIfNotAuth();
                    AddTagCommand addTag = new AddTagCommand();
                    result = addTag.Execute(parameters);
                    break;
                case "CreateAlbum":
                    CheckIfNotAuth();
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand();
                    result = createAlbum.Execute(parameters);
                    break;
                case "AddTagTo":
                    CheckIfNotAuth();
                    AddTagToCommand addTagTo = new AddTagToCommand();
                    result = addTagTo.Execute(parameters);
                    break;
                case "MakeFriends":
                    CheckIfNotAuth();
                    MakeFriendsCommand makeFriends = new MakeFriendsCommand();
                    result = makeFriends.Execute(parameters);
                    break;
                case "ListFriends":
                    CheckIfAuth();
                    ListFriendsCommand listFriends = new ListFriendsCommand();
                    result = listFriends.Execute(parameters);
                    break;
                case "ShareAlbum":
                    CheckIfNotAuth();
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand();
                    result = shareAlbum.Execute(parameters);
                    break;
                case "UploadPicture":
                    CheckIfNotAuth();
                    UploadPictureCommand uploadPicture = new UploadPictureCommand();
                    result = uploadPicture.Execute(parameters);
                    break;
                case "Login":
                    CheckIfAuth();
                    LoginUserCommand loginUser = new LoginUserCommand();
                    result = loginUser.Execute(parameters);
                    break;
                case "Logout":
                    CheckIfNotAuth();
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute();
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    result = exit.Execute();
                    break;
                case "":
                    result = "";
                    break;
                default:
                    throw new InvalidOperationException($"Command {cmd} not valid!");
            }
           
            return result;  
        }

        private static void CheckIfNotAuth()
        {
            if (!Authentication.isAuthenticated())
                throw new InvalidOperationException($"Invalid Credentials!");
        }
        private static void CheckIfAuth()
        {
            if (Authentication.isAuthenticated())
                throw new InvalidOperationException($"Invalid Credentials!");
        }
    }
}
