namespace Agenda.UI.Common.Dtos;

public class TokenDto(bool valid, string token, string refreshToken)
{
    public bool Valid { get; set; } = valid;
    public string Token { get; set; } = token;
    public string RefreshToken { get; set; } = refreshToken;
}