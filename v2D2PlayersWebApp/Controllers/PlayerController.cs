using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Player;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayer_Service _player_Service;
        public PlayerController(IPlayer_Service player_Service)
        {
            _player_Service = player_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPlayer(Player_Pass_Object player)
        {
            var result = await _player_Service.AddPlayer(player.firstName, player.lastName, player.nickName, player.age,
                player.teamId, player.countryId, player.prizeMoney);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPlayers()
        {
            var result = await _player_Service.GetAllPlayers();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPlayerById(int id)
        {
            var result = await _player_Service.GetPlayerById(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }

        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPlayersByTeamId(int id)
        {
            var result = await _player_Service.GetPlayersByTeamId(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }

        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> UpdatePlayer(PlayerUpdate_Pass_Object player)
        {
            var result = await _player_Service.UpdatePlayer(player.id, player.firstName, player.lastName, player.nickName, player.age,
                player.teamId, player.countryId, player.prizeMoney);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
