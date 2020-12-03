using System;
using Core.Enums;

namespace WebAdminApp.Models
{
    public class SoccerEventDto
    {
        public Guid Id { get; set; }
        public SoccerEventType SoccerEventType { get; set; }
        public SoccerPlayerDto SoccerPlayer { get; set; }
    }
}