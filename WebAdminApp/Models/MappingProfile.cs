using AutoMapper;
using Core.Entities;

namespace WebAdminApp.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SoccerGame, SoccerGameDto>();
            CreateMap<SoccerEvent, SoccerEventDto>();
            CreateMap<SoccerTeam, SoccerTeamDto>();
            CreateMap<SoccerPlayer, SoccerPlayerDto>();
        }
    }
}