using System.Collections.Generic;

namespace Core.Entities
{
    public class SoccerTeam : BaseEntity
    {
        /// <summary>
        /// Id of the team
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of players
        /// </summary>
        public virtual List<SoccerPlayer> Players { get; set; }

        /// <summary>
        /// Each Team has a list of events
        /// </summary>
        public virtual List<SoccerEvent> SoccerEvents { get; set; }
    }
}