using MockProject.Domain.Repositories;
using MockProject.Domain.Entities;

using MediatR;

namespace MockProject.Application.Commands
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUsernamePasswordAsync(request.UserName, request.Password);
        }
    }
}
