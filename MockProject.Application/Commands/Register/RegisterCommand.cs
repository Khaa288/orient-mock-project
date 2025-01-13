using MediatR;

namespace MockProject.Application.Commands
{
    public sealed class RegisterCommand : IRequest
    {
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }

        public RegisterCommand(string email, string userName, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
