using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Enums;
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
    public class EventController : ApiBaseController
    {
        private readonly ILogger<EventController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public EventController(ILogger<EventController> logger, IMapper mapper, IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> Get(int gameId)
        {
            _logger.LogInformation($"Retrieve all games by userID: {_currentUserService.UserId}");
            var events = await _unitOfWork.EventRepository.GetAllAsync(gameId);
            var result = _mapper.Map<List<SoccerEventDto>>(events);
            return Ok(result);
        }

        [HttpGet("{gameId}/{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int gameId, Guid eventId)
        {
            _logger.LogInformation($"Retrieve event for ID: {eventId} by userID: {_currentUserService.UserId}");
            var gameEvent = await _unitOfWork.EventRepository.GetByIdAsync(gameId, eventId);
            if (gameEvent == null)
            {
                _logger.LogError($"Specified eventId {eventId} is not found.");
                return NotFound();
            }

            var result = _mapper.Map<SoccerEventDto>(gameEvent);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGameEvent([FromBody] CreateSoccerEventDto dto)
        {
            try
            {
                _logger.LogInformation($"Create new event by userID: {_currentUserService.UserId}");
                var newGameEvent = _mapper.Map<SoccerEvent>(dto);
                var game = await _unitOfWork.GameRepository.GetByIdAsync(dto.SoccerGameId);
                if (game != null && game.GameStatus == GameStatus.InProgress)
                {
                    var result = _unitOfWork.EventRepository.Add(newGameEvent);
                    await _unitOfWork.CompleteAsync();
                    if (result != null)
                        return CreatedAtAction(nameof(Get), new {eventId = result.Id},
                            _mapper.Map<SoccerEventDto>(result));
                }

                _logger.LogError($"Something went wrong to create new event");
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside StopGame action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPut("[action]/{eventId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGameEvent(Guid eventId, [FromBody] CreateSoccerEventDto dto)
        {
            try
            {
                _logger.LogInformation($"Update new event by userID: {_currentUserService.UserId}");
                var game = await _unitOfWork.GameRepository.GetByIdAsync(dto.SoccerGameId);
                var soccerEvent = await _unitOfWork.EventRepository.GetByIdAsync(dto.SoccerGameId, eventId);
                if (game != null && game.GameStatus == GameStatus.InProgress && soccerEvent != null)
                {
                    soccerEvent.SoccerTeamId = dto.SoccerTeamId;
                    soccerEvent.SoccerPlayerId = dto.SoccerPlayerId;
                    soccerEvent.SoccerEventType = dto.SoccerEventType;
                    
                    var result = _unitOfWork.EventRepository.Update(soccerEvent);
                    await _unitOfWork.CompleteAsync();
                    if (result != null)
                        return NoContent();
                }

                _logger.LogError($"Something went wrong to create new event");
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