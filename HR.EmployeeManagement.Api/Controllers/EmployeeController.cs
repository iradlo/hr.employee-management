using HR.EmployeeManagement.Application.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeBasicVM>>> GetAllEmployees(bool includeTeamData)
        {
            var employees = await _mediator.Send(new GetEmployeeListQuery() { IncludeTeamData = includeTeamData });
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailVM>> GetEmployeeById(int id)
        {
            var getEmployeeDetailsQuery = new GetSingleEmployeeQuery() { Id = id };
            return Ok(await _mediator.Send(getEmployeeDetailsQuery));
        }

        [HttpPost(Name = "CreateNewEmployee")]
        public async Task<ActionResult<int>> CreateNewEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var id = await _mediator.Send(createEmployeeCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEmployeeCommand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteEmployeeCommand() { EmployeeId = id };
            await _mediator.Send(deleteCommand);

            return NoContent();
        }
    }
}
