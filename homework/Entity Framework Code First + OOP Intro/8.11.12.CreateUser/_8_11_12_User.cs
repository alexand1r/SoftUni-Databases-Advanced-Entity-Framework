namespace _8.CreateUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class _8_11_12_User
    {
        static void Main(string[] args)
        {
            var context = new UserContext();
            //// 8.Create User
            //context.Database.Initialize(true);

            //// 11.Get User By Email Provider
            //string input = Console.ReadLine();
            //var usersByEmail = GetUsersByEmailProvider(context, input);
            //foreach (User user in usersByEmail)
            //{
            //    Console.WriteLine($"{user.Username} {user.Email}");
            //}

            //// 12.Remove Inactive Users
            string input = Console.ReadLine();
            var usersForDeletion = GetUsersForDeletion(context, input);
            var count = usersForDeletion.Count == 0 ? "No" : (usersForDeletion.Count).ToString();
            Console.WriteLine($"{count} users have been deleted.");
            foreach (User user in usersForDeletion)
            {
                context.Users.Remove(user);
            }
            context.SaveChanges();
        }

        public static List<User> GetUsersByEmailProvider(UserContext context, string input)
        {
            var users = context.Users
                .Where(u => u.Email.Substring(u.Email.Length - input.Length) == input)
                .ToList();
          
            return users;
        }

        public static List<User> GetUsersForDeletion(UserContext context, string input)
        {
            string[] data = input.Trim().Split(' ');
            int day = int.Parse(data[0]);
            int month = ConvertMonth(data[1]);
            int year = int.Parse(data[2]);
            DateTime inputDate = new DateTime(year, month, day);
            var usersForDeletion = context.Users
                .Where(u => u.LastTimeLoggedIn <= inputDate)
                .ToList();

            return usersForDeletion;
        }

        public static int ConvertMonth(string month)
        {
            int num = 0;
            switch (month)
            {
                case "Jan":
                    num = 1;
                    break;
                case "Feb":
                    num = 2;
                    break;
                case "Mar":
                    num = 3;
                    break;
                case "Apr":
                    num = 4;
                    break;
                case "May":
                    num = 5;
                    break;
                case "Jun":
                    num = 6;
                    break;
                case "Jul":
                    num = 7;
                    break;
                case "Aug":
                    num = 8;
                    break;
                case "Sep":
                    num = 9;
                    break;
                case "Oct":
                    num = 10;
                    break;
                case "Nov":
                    num = 11;
                    break;
                case "Dec":
                    num = 12;
                    break;
            }
            return num;
        }
    }
}
