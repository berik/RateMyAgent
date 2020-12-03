using Core.Enums;

namespace WebAdminApp.Models
{
    public class SoccerPlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SoccerPlayerType SoccerPlayerType { get; set; }
    }
}