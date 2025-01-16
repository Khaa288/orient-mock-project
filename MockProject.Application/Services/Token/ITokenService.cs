using MockProject.Domain.Entities;

namespace MockProject.Application.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user, string tokenType);
    }
}
