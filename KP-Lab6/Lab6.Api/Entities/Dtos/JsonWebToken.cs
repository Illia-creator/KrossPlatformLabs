using System.Security.Claims;

namespace Lab6.Api.Entities.Dtos;
public class JsonWebToken
{
    public JsonWebToken(
        string acessToken,
        long expires,
        string userGid,
        IEnumerable<Claim>? claims)
    {
        AccessToken = acessToken;
        Expires = expires;
        UserGid = userGid;
        Claims = claims;
    }

    public string AccessToken { get; }

    public long Expires { get; }

    public string UserGid { get; }

    public IEnumerable<Claim>? Claims { get; }
}