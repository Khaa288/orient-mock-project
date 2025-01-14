using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Common;
using MockProject.API.Dtos;
using MockProject.Application.Commands;
using MockProject.Domain.Entities;

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
            var user = await _mediator.Send(new LoginCommand(request.Username, request.Password));

            return Ok(new ApiResponse()
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Result = user
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto request)
        {
            int isRegistered = await _mediator.Send(new RegisterCommand(request.Email, request.Username, request.Password));

            return Ok(new ApiResponse()
            {
                IsSuccess = isRegistered == 1,
                StatusCode = isRegistered == 1 ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                Result = isRegistered
            });
        }
    }
}
