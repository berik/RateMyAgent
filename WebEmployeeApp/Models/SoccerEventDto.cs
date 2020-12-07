using System;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace WebEmployeeApp.Models
{
    public class SoccerEventDto
    {
        public Guid Id { get; set; }
        public int SoccerGameId { get; set; }
        public int SoccerTeamId { get; set; }
        public SoccerPlayerDto SoccerPlayer { get; set; }
        public SoccerEventType SoccerEventType { get; set; }
    }

    public class CreateSoccerEventDto
    {
        [Required]
        public int SoccerGameId { get; set; }
        [Required]
        public int SoccerPlayerId { get; set; }
        [Required]
        public int SoccerTeamId { get; set; }
        public SoccerEventType SoccerEventType { get; set; }
    }
}