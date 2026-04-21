namespace Agenda.UI.Common.Dtos;

public class LoginResponseDto(bool authorized, string token, int tokenExpirationMin, string refreshToken, int refreshTokenExpirationHour)
{
    public bool Authorized { get; set; } = authorized;
    public string Token { get; set; } = token;
    public int TokenExpirationMin { get; set; } = tokenExpirationMin;
    public string RefreshToken { get; set; } = refreshToken;
    public int RefreshTokenExpirationHour { get; set; } = refreshTokenExpirationHour;
}