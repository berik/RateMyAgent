using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;

namespace Core.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SoccerGame> AssignGameToUser(SoccerGame soccerGame, string userId)
        {
            if (!string.IsNullOrEmpty(soccerGame.ReporterId)) return null;
            
            soccerGame.ReporterId = userId;
            _unitOfWork.GameRepository.Update(soccerGame);
            await _unitOfWork.CompleteAsync();
            return soccerGame;
        }

        public async Task<SoccerGame> StartGame(SoccerGame soccerGame, string userId)
        {
            if (string.IsNullOrEmpty(soccerGame.ReporterId)) return null;

            if (soccerGame.GameStatus == GameStatus.NotStarted)
            {
                soccerGame.GameStatus = GameStatus.InProgress;
                _unitOfWork.GameRepository.Update(soccerGame);
                await _unitOfWork.CompleteAsync();
                return soccerGame;
            };

            return null;
        }
    }
}