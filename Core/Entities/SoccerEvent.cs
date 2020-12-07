using System;
using Core.Enums;

namespace Core.Entities
{
    public class SoccerEvent : BaseEntity
    {
        /// <summary>
        /// Guid, because for events it's easier to create random GUID and add record to DB then ID which has limit ^32
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Soccer game ID
        /// </summary>
        public int SoccerGameId { get; set; }
        
        /// <summary>
        /// Soccer player ID
        /// </summary>
        public int SoccerPlayerId { get; set; }
        
        /// <summary>
        /// Soccer team ID
        /// </summary>
        public int SoccerTeamId { get; set; }
        
        /// <summary>
        /// Type event
        /// </summary>
        public SoccerEventType SoccerEventType { get; set; }
        
        /// <summary>
        /// Nav.property
        /// </summary>
        public virtual SoccerGame SoccerGame { get; set; }
        
        /// <summary>
        /// Nav.property
        /// </summary>
        public virtual SoccerPlayer SoccerPlayer { get; set; }
        
        /// <summary>
        /// Nav.property
        /// </summary>
        public virtual SoccerTeam SoccerTeam { get; set; }
    }
}