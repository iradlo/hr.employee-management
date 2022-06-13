using HR.EmployeeManagement.Application.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("login")]
        [HttpPost(Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginInfo>> Login([FromBody] LoginUserCommand loginCommand)
        {
            var login = await _mediator.Send(loginCommand);
            return Ok(login);
        }

        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UsersVM>>> GetAllUsers()
        {
            try
            {
                var allUsers = await _mediator.Send(new GetUsersListQuery());
                return Ok(allUsers);
            }
            catch (Exception)
            {
                return BadRequest("Failed to fetch users");
            }
        }

        [HttpPost("register", Name = "Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Register([FromBody] RegisterUserCommand registerCommand)
        {
            try
            {
                var id = await _mediator.Send(registerCommand);
                return Ok(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = id });
            return NoContent();
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }
    }
}
