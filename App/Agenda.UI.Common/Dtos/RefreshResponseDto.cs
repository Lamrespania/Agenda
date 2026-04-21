namespace Agenda.UI.Common.Dtos;

public class RefreshResponseDto(bool authorized, string token, int tokenLifetimeMin)
{
    public bool Authorized { get; set; } = authorized;
    public string Token { get; set; } = token;
    public int TokenLifetimeMin { get; set; } = tokenLifetimeMin;
}