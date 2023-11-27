using Lab6.Api.Entities.Dtos;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab6.Api.Services;

public interface IJwtTokenProvider
{
    Entities.Dtos.JsonWebToken CreateToken(
        string userGid,
        string userName
        );
}

public interface IUtcClock
{
    DateTime GetUtcClock();
}

internal sealed class UtcClock : IUtcClock
{
    public DateTime GetUtcClock()
        => DateTime.UtcNow;
}

public interface IJwtTokenGenerator
{
    string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        DateTime expiry,
        IEnumerable<Claim> claims
    );
}
public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        DateTime expiry,
        IEnumerable<Claim> claims
        )
    {
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            DateTime.UtcNow,
            expiry,
            credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

internal static class Extensions
{
    internal static long ToTimestamp(this DateTime date)
    {
        var centuryBegin = DateTime.UnixEpoch;

        var expectedDate = date.Subtract(new TimeSpan(centuryBegin.Ticks));

        return expectedDate.Ticks / 10000;
    }

    public static IServiceCollection AddTime(this IServiceCollection services)
     => services.AddScoped<IUtcClock, UtcClock>();

    public static T BindOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
      => BindOptions<T>(configuration.GetSection(sectionName));

    public static T BindOptions<T>(this IConfigurationSection section) where T : new()
    {
        var options = new T();
        section.Bind(options);
        return options;
    }

}
public class JwtTokenProvider : IJwtTokenProvider
{
    private readonly IUtcClock _clock;
    private readonly JwtOptions _jwtOptions;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public JwtTokenProvider(
        IUtcClock clock,
        JwtOptions jwtOptions,
        IJwtTokenGenerator tokenGenerator)
    {
        _clock = clock;
        _jwtOptions = jwtOptions;
        _tokenGenerator = tokenGenerator;
    }

    Entities.Dtos.JsonWebToken IJwtTokenProvider.CreateToken(string userId, string userName)
    {
        var now = _clock.GetUtcClock();

        var jwtClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userId),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
        };

        if (!string.IsNullOrWhiteSpace(userName))
            jwtClaims.Add(new Claim(ClaimTypes.Name, userName));

        var expires = now.AddMinutes(_jwtOptions.ExpiryMinutes);

        var jwt = _tokenGenerator.GenerateToken(
            _jwtOptions.SecretKey,
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            expires,
            jwtClaims);

        return new Entities.Dtos.JsonWebToken(
            jwt,
            expires.ToTimestamp(),
            userId,
            jwtClaims);
    }


}
