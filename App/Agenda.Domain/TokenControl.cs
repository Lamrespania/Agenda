namespace Agenda.Domain;

public class TokenControl(int id, int userId, string token, string refreshToken, DateTime refreshTokenExpiringDate)
{
    public int Id { get; set; } = id;
    public int UserId { get; set; } = userId;
    public string Token { get; set; } = token;
    public string RefreshToken { get; set; } = refreshToken;
    public DateTime RefreshTokenExpiringDate { get; set; } = refreshTokenExpiringDate;
}