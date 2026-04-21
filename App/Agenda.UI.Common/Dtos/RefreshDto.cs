namespace Agenda.UI.Common.Dtos;

public class RefreshDto(string username, string refreshToken)
{
    public string Username { get; set; } = username;
    public string RefreshToken { get; set; } = refreshToken;
}