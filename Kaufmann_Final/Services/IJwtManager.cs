using Kaufmann_Final.Models;

namespace Kaufmann_Final.Services
{
    public interface IJwtManager
    {
        string CreateJwt(User user);
    }
}