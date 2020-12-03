using System.Collections.Generic;

namespace WebAdminApp.Models
{
    public class SoccerTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SoccerPlayerDto> Players { get; set; } = new List<SoccerPlayerDto>();
    }
}