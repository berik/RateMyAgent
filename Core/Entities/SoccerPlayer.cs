using System.Collections.Generic;
using Core.Enums;

namespace Core.Entities
{
    public class SoccerPlayer : BaseEntity
    {
        /// <summary>
        /// Id of the player
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Soccer player type
        /// </summary>
        public SoccerPlayerType SoccerPlayerType { get; set; }

        /// <summary>
        /// Soccer team ID
        /// </summary>
        public int SoccerTeamId { get; set; }
        
        /// <summary>
        /// Nav.Property
        /// </summary>
        public virtual SoccerTeam SoccerTeam { get; set; }

        /// <summary>
        /// Each player has a list of soccer events
        /// </summary>
        public List<SoccerEvent> SoccerEvents { get; set; }
    }
}