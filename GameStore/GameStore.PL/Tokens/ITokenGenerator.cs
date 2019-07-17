using System.Collections.Generic;
using System.Security.Claims;

namespace GameStore.PL.Tokens
{
    public interface ITokenGenerator
    {
        string GetToken(List<Claim> claims);
    }
}
