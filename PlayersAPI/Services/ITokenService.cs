using PlayersAPI.Models;

namespace PlayersAPI.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);
    }
}
