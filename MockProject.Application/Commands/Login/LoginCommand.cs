using MockProject.Domain.Entities;

using MediatR;

namespace MockProject.Application.Commands
{
    public sealed class LoginCommand : IRequest<string>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
