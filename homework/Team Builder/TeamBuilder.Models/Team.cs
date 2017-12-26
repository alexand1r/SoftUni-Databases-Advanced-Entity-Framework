using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Events = new List<Event>();
            this.Invitations = new List<Invitation>();
            this.Members = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(3)]
        public string Acronym { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Members { get; set; }
    }
}
