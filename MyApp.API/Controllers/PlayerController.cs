using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Interfaces;

namespace MyApp.API.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IRepositoryWrapper repository, ILogger<PlayerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var players = await _repository.Player.GetAllPlayers();
                return Ok(players);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
