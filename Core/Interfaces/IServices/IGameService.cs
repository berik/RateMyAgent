using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.IServices
{
    public interface IGameService
    {
        Task<SoccerGame> StartGame(SoccerGame soccerGame, string userId);
        Task<SoccerGame> StopGame(SoccerGame soccerGame);
    }
}