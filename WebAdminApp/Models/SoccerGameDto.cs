using System;
using System.Collections.Generic;
using Core.Enums;

namespace WebAdminApp.Models
{
    public class SoccerGameDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public GameStatus GameStatus { get; set; }
        public string ReporterId { get; set; }
        public List<SoccerEventDto> SoccerEvents { get; set; }
        public SoccerTeamDto HomeSoccerTeam { get; set; }
        public SoccerTeamDto GuestSoccerTeam { get; set; }
    }
}