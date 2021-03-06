using AutoMapper;
using Core.Entities;

namespace WebEmployeeApp.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SoccerGame, SoccerGameDto>();
            CreateMap<SoccerEvent, SoccerEventDto>();
            CreateMap<CreateSoccerEventDto, SoccerEvent>();
            CreateMap<SoccerTeam, SoccerTeamDto>();
            CreateMap<SoccerPlayer, SoccerPlayerDto>();
        }
    }
}