using Cannabis.Core.Entities.Identity;

namespace Cannabis.Core.Interfaces.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
