using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Team;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeam_Service _team_Service;

        public TeamController(ITeam_Service team_Service)
        {
            _team_Service = team_Service;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddTeam(Team_Pass_Object team)
        {
            var result = await _team_Service.AddTeam(team.name, team.region);
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

        public async Task<IActionResult> GetTeams()
        {
            var result = await _team_Service.GetAllTeams();
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

        public async Task<IActionResult> GetTeamById(int id)
        {
            var result = await _team_Service.GetTeamById(id);
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

        public async Task<IActionResult> UpdateTeam(TeamUpdate_Pass_Object team)
        {
            var result = await _team_Service.UpdateTeam(team.id, team.name, team.region);
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
