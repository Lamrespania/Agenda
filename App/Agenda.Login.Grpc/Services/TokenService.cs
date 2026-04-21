namespace Agenda.Login.Grpc.Services;

public class TokenService(RsaSecurityKey securityKey)
{
    private readonly RsaSecurityKey _securityKey = securityKey;

    public string Generate(User user)
    {
        Claim[] claims = [new(ClaimTypes.NameIdentifier, user.Username), new(ClaimTypes.Role, user.Role.ToString())];

        SigningCredentials credentials = new(_securityKey, SecurityAlgorithms.RsaSha256);

        short tokenLifetimeMinutes = short.Parse(Environment.GetEnvironmentVariable(GrpcConstants.USER_TOKEN_LIFETIME_MIN));

        JwtSecurityToken securityToken = new(
            issuer: CommonConstants.API_NAME,
            audience: CommonConstants.API_NAME,
            claims: claims,
            expires: DateTime.Now.AddMinutes(tokenLifetimeMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}