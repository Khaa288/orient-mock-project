using MockProject.API.Dtos;
using MockProject.Application.Commands;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MockProject.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto request)
        {
            var token = await _mediator.Send(new LoginCommand(request.Username, request.Password));
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto request)
        {
            await _mediator.Send(new RegisterCommand(request.Email, request.Username, request.Password));
            return Ok();
        }
    }
}
