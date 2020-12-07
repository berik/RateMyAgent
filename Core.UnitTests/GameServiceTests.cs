using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Core.Services;
using Moq;
using NUnit.Framework;

namespace Core.UnitTests
{
    public class GameServiceTests
    {
        private IGameService _gameService;
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task IfGameHasStarted_ItShouldReturn_Null()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.InProgress
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));

            // Act
            var result = await _gameService.StartGame(mockGame, userId);

            // Assert
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public async Task IfGameHasCompleted_ItShouldReturn_Null()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.Finished
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));

            // Act
            var result = await _gameService.StartGame(mockGame, userId);

            // Assert
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public async Task IfGameHasNotStarted_ItShouldReturn_InProgress()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.NotStarted
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));

            // Act
            var result = await _gameService.StartGame(mockGame, userId);

            // Assert
            Assert.AreEqual(GameStatus.InProgress, result.GameStatus);
        }

        [Test]
        public async Task IfGameIsAlreadyFinished_ItShouldReturnNull()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.Finished
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));
            
            // Act
            var result = await _gameService.StopGame(mockGame);
            
            // Assert
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public async Task IfGameHasNotStarted_ItShouldReturnNull()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.NotStarted
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));
            
            // Act
            var result = await _gameService.StopGame(mockGame);
            
            // Assert
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public async Task IfGameInProgress_ItShouldReturnSuccess()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockGame = new SoccerGame()
            {
                Id = 1,
                ReporterId = Guid.NewGuid().ToString(),
                GameStatus = GameStatus.InProgress
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));
            
            // Act
            var result = await _gameService.StopGame(mockGame);
            
            // Assert
            Assert.AreEqual(GameStatus.Finished, result.GameStatus);
        }
    }
}