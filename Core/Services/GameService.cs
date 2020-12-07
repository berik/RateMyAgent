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
        
        public async Task<SoccerGame> StartGame(SoccerGame soccerGame, string userId)
        {
            if (soccerGame.GameStatus == GameStatus.NotStarted)
            {
                soccerGame.GameStatus = GameStatus.InProgress;
                soccerGame.ReporterId = userId;
                _unitOfWork.GameRepository.Update(soccerGame);
                await _unitOfWork.CompleteAsync();
                return soccerGame;
            };

            return null;
        }

        public async Task<SoccerGame> StopGame(SoccerGame soccerGame)
        {
            if (soccerGame.GameStatus == GameStatus.InProgress)
            {
                soccerGame.GameStatus = GameStatus.Finished;
                _unitOfWork.GameRepository.Update(soccerGame);
                await _unitOfWork.CompleteAsync();
                return soccerGame;
            };

            return null;
        }
    }
}