using System.Collections.Generic;
using Core.Enums;

namespace Core.Entities
{
    public class SoccerGame : BaseEntity
    {
        /// <summary>
        /// Id of the game
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the game.
        /// For Soccer it will be: Manchester United vs Barcelona
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status of the game
        /// </summary>
        public GameStatus GameStatus { get; set; }

        /// <summary>
        /// Person is responsible for reporting this game
        /// </summary>
        public string ReporterId { get; set; }

        /// <summary>
        /// Home team soccer Id
        /// </summary>
        public int HomeSoccerTeamId { get; set; }

        /// <summary>
        /// Guest team soccer Id
        /// </summary>
        public int GuestSoccerTeamId { get; set; }

        /// <summary>
        /// List of "important events"
        /// </summary>
        public virtual List<SoccerEvent> SoccerEvents { get; set; } = new List<SoccerEvent>();
        
        /// <summary>
        /// Nav.Property
        /// </summary>
        public virtual ApplicationUser Reporter { get; set; }
        
        /// <summary>
        /// Nav.Property 
        /// </summary>
        public virtual SoccerTeam HomeSoccerTeam { get; set; }
        
        /// <summary>
        /// Nav.Property
        /// </summary>
        public virtual SoccerTeam GuestSoccerTeam { get; set; }
    }
}