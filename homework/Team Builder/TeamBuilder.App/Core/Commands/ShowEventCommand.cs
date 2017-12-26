using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class ShowEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string eventName = inputArgs[0];
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            return this.ShowEvent(eventName);
        }

        private string ShowEvent(string eventName)
        {
            StringBuilder sb = new StringBuilder();

            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Event ev =
                context.Events.FirstOrDefault(e => e.Name == eventName);

                sb.AppendLine($"{ev.Name} {ev.StartDate} {ev.EndDate}");
                sb.AppendLine($"{ev.Description}");
                sb.AppendLine("Teams:");
                foreach (Team t in ev.ParticipatingTeams)
                {
                    sb.AppendLine($"-{t.Name}");
                }
            }

            return sb.ToString();
        }
    }
}
