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
        public List<SoccerPlayer> Players { get; set; } = new List<SoccerPlayer>();

        /// <summary>
        /// Each Team has a list of Past/Future games
        /// </summary>
        public List<SoccerGame> SoccerGames { get; set; } = new List<SoccerGame>();
    }
}