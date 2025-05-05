using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Shared.RequestParameters;

namespace MyApp.API.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IRepositoryWrapper repository, ILogger<PlayerController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers([FromQuery] PlayerParameter parameter)
        {
            try
            {
                var players = await _repository.Player.GetPlayers(parameter);
                var result = _mapper.Map<IEnumerable<PlayerDto>>(players);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "PlayerById")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerById(id);
                if (player is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerDto>(player);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/characters")]
        public async Task<IActionResult> GetPlayerWithCharacters(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerWithCharacters(id);
                if (player is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerWithCharactersDto>(player);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerForCreationDto playerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("無效的請求數據");
                }

                var player = _mapper.Map<Player>(playerDto);
                _repository.Player.Create(player);
                await _repository.Save();

                var createdPlayer = _mapper.Map<PlayerDto>(player);
                return CreatedAtRoute("PlayerById", new { id = createdPlayer.Id }, createdPlayer);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] PlayerForUpdateDto player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("無效的請求數據");
                }
                var playerEntity = await _repository.Player.GetPlayerById(id);
                if (playerEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(player, playerEntity);
                _repository.Player.Update(playerEntity);
                await _repository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerWithCharacters(id);
                if (player is null)
                {
                    return BadRequest("該名玩家不存在");
                }
                if (player.Characters.Any())
                {
                    return BadRequest("該名玩家有關聯人物角色，不能刪除！");
                }
                _repository.Player.Delete(player);
                await _repository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
