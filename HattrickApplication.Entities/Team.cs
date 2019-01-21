using System.Collections.Generic;

namespace HattrickApplication.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual IEnumerable<Event> Events { get; set; }
    }
}