using System;
using System.Globalization;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class CreateEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(6, inputArgs);
            AuthenticationManager.Authorize();

            string eventName = inputArgs[0];
            string description = inputArgs[1];

            DateTime startDateTime;

            bool isStartDateTime = DateTime.TryParseExact(
                inputArgs[2] + " " + inputArgs[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out startDateTime);

            DateTime endDateTime;

            bool isEndDateTime = DateTime.TryParseExact(
                inputArgs[4] + " " + inputArgs[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out endDateTime);

            if (!isEndDateTime || !isStartDateTime)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }

            if (startDateTime > endDateTime)
            {
                throw new ArgumentException($"Wrong Dates");
            }

            this.CreateEvent(eventName, description, startDateTime, endDateTime);

            return $"Event {eventName} was created successfully!";
        }

        private void CreateEvent(string eventName, string description, DateTime startDateTime, DateTime endDateTime)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Event e = new Event()
                {
                    Name = eventName,
                    Description = description,
                    StartDate = startDateTime,
                    EndDate = endDateTime,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                };

                context.Events.Add(e);
                context.SaveChanges();
            }
        }
    }
}
