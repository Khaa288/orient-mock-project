using MediatR;
using MockProject.Application.Constants;
using MockProject.Application.Services.Token;
using MockProject.Domain.Repositories;

namespace MockProject.Application.Commands
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernamePasswordAsync(request.UserName, request.Password);

            if (user is null)
            {
                return string.Empty;
            }

            return _tokenService.CreateToken(user, TokenTypeNames.Access);
        }
    }
}
