using System;

namespace API;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
