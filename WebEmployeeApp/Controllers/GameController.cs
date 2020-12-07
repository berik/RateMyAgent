using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebEmployeeApp.Models;

namespace WebEmployeeApp.Controllers
{
    [Authorize]
    public class GameController : ApiBaseController
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IGameService _gameService;

        public GameController(ILogger<GameController> logger, IMapper mapper, IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService, IGameService gameService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Retrieve all games by userID: {_currentUserService.UserId}");
            var games = await _unitOfWork.GameRepository.GetAllAsync();
            var gameDtos = _mapper.Map<List<SoccerGameDto>>(games);
            return Ok(gameDtos);
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int gameId)
        {
            _logger.LogInformation($"Retrieve game for ID: {gameId} by userID: {_currentUserService.UserId}");
            var game = await _unitOfWork.GameRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                _logger.LogError($"Specified gameId {gameId} is not found.");
                return NotFound();
            }

            var gameDto = _mapper.Map<SoccerGameDto>(game);
            return Ok(gameDto);
        }
        
        [HttpPut("[action]/{gameId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> StartGame(int gameId)
        {
            try
            {
                if (gameId == 0)
                {
                    _logger.LogError($"Specified gameId {gameId} sent from client is null.");
                    return BadRequest();
                }

                var soccerGame = await _unitOfWork.GameRepository.GetByIdAsync(gameId);
                if (soccerGame == null)
                {
                    _logger.LogError($"Specified gameId {gameId} is not found.");
                    return NotFound();
                }

                var result = await _gameService.StartGame(soccerGame, _currentUserService.UserId);
                if (result != null)
                {
                    return NoContent(); 
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside StartGame action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPut("[action]/{gameId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> StopGame(int gameId)
        {
            try
            {
                if (gameId == 0)
                {
                    _logger.LogError($"Specified gameId {gameId} sent from client is null.");
                    return BadRequest();
                }

                var soccerGame = await _unitOfWork.GameRepository.GetByIdAsync(gameId);
                if (soccerGame == null)
                {
                    _logger.LogError($"Specified gameId {gameId} is not found.");
                    return NotFound();
                }

                var result = await _gameService.StopGame(soccerGame);
                if (result != null)
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside StopGame action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}