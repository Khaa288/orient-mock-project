using MediatR;
using MockProject.Domain.Repositories;

namespace MockProject.Application.Commands
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateUserAsync(request.Email, request.UserName, request.Password);
        }
    }
}
