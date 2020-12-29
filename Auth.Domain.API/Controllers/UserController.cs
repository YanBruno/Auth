using Auth.Domain.Commands.UserCommands;
using Auth.Domain.Entities;
using Auth.Domain.Handlers;
using Auth.Domain.Repositories;
using Auth.Domain.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Domain.API.Controllers
{
    [Route("v1/account/")]
    public class UserController : Controller
    {
        private readonly UserHandler _handler;
        private readonly IUserRepository _repository;
        public UserController([FromServices] UserHandler handler, [FromServices] IUserRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("users")]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _repository.GetUsers();
            return result;
        }
        
        [HttpDelete]
        [Route("users/{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ICommandResult> Delete(Guid id, [FromBody] DeleteUserCommand command)
        {
            command.Id = id;
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpPost]
        [Route("signUp")] //Register
        [AllowAnonymous]
        public async Task<ICommandResult> SignUp([FromBody] CreateUserCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpPost]
        [Route("signIn")] //Login
        [AllowAnonymous]
        public Task<ICommandResult> Authentication([FromBody] AuthenticateUserCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("email")] //Change email
        [Authorize]
        public Task<ICommandResult> PutEmail([FromBody] UpdateEmailUserCommand command)
        {
            command.Id = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            command.Email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("name")] //Change name
        [Authorize]
        public Task<ICommandResult> PutName([FromBody] UpdateNameUserCommand command)
        {
            command.Id = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            command.Email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("password")] //Change Password
        [Authorize]
        public Task<ICommandResult> PutPassword([FromBody] UpdatePasswordUserCommand command)
        {
            command.Id = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            command.Email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("role")] //Change Role
        [Authorize]
        public Task<ICommandResult> PutRole([FromBody] UpdateRoleUserCommand command)
        {
            command.Id = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            command.Email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _handler.Handle(command);
            return result;
        }
    }
}
