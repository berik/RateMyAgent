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
        public async Task IfGameDoesNotHaveReporter_ItShouldAssignAndReturn_ReporterId()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var gameId = 1;
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = gameId,
                ReporterId = ""
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));

            // Act
            var result = await _gameService.AssignGameToUser(mockGame, userId);

            // Assert
            Assert.AreEqual(userId, result.ReporterId);
        }
        
        [Test]
        public async Task IfGameHasReporter_ItShouldReturnReturn_Null()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var gameId = 1;
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = gameId,
                ReporterId = Guid.NewGuid().ToString()
            };
            _gameService = new GameService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(p => p.GameRepository.Update(mockGame));

            // Act
            var result = await _gameService.AssignGameToUser(mockGame, userId);

            // Assert
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public async Task IfGameHasStarted_ItShouldReturn_Null()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var gameId = 1;
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = gameId,
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
            var gameId = 1;
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = gameId,
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
            var gameId = 1;
            var userId = Guid.NewGuid().ToString();
            var mockGame = new SoccerGame()
            {
                Id = gameId,
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
    }
}