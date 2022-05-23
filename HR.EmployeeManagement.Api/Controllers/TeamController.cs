using HR.EmployeeManagement.Application.Features.Teams;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTeams")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TeamVM>>> GetAllTeams()
        {
            var employees = await _mediator.Send(new GetTeamsListQuery());
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetTeamById")]
        public async Task<ActionResult<TeamDetailsVM>> GetTeamById(int id)
        {
            var getTeamDetails = new GetTeamDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(getTeamDetails));
        }

        [HttpPost(Name = "CreateNewTeam")]
        public async Task<ActionResult<int>> CreateNewTeam([FromBody] CreateNewTeamCommand createTeamCommand)
        {
            var id = await _mediator.Send(createTeamCommand);
            return Ok(id);
        }

        [HttpPut(Name = "Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTeamCommand updateTeamCommand)
        {
            await _mediator.Send(updateTeamCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTeam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            var deleteCommand = new DeleteTeamCommand() { TeamId = id };
            await _mediator.Send(deleteCommand);

            return NoContent();
        }
    }
}
