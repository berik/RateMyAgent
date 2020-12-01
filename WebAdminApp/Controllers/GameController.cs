using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAdminApp.Models;

namespace WebAdminApp.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GameController
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public GameController(ILogger<GameController> logger, IMapper mapper, IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<List<SoccerGameDto>> Get()
        {
            _logger.LogInformation($"Retrieved all games by userID: {_currentUserService.UserId}");
            var games = await _unitOfWork.GameRepository.GetAllAsync();
            var gameDtos = _mapper.Map<List<SoccerGameDto>>(games);
            return gameDtos;
        }
    }
}