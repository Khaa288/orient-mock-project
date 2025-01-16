using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Common;
using MockProject.API.Dtos;
using MockProject.Application.Commands;

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

            if (string.IsNullOrEmpty(token))
            {
                return NotFound(new ApiResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound
                });
            }

            return Ok(new ApiResponse()
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Result = token
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto request)
        {
            int isRegistered = await _mediator.Send(new RegisterCommand(request.Email, request.Username, request.Password));

            if (isRegistered == 0)
            {
                return NotFound(new ApiResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound
                });
            }

            return Ok(new ApiResponse()
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.Created,
                Result = isRegistered
            });
        }
    }
}
