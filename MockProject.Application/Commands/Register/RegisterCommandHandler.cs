using MockProject.Domain.Repositories;

using MediatR;

namespace MockProject.Application.Commands
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateUserAsync(request.Email, request.UserName, request.Password);
        }
    }
}
