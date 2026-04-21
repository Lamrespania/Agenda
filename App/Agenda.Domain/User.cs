namespace Agenda.Domain;

public class User(int id, string username, string password, UserRole role, DateTime created)
{
    public int Id { get; private set; } = id;
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public UserRole Role { get; private set; } = role;
    public DateTime Created { get; private set; } = created;
}