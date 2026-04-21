namespace Agenda.Api.Services;

public class LoginService
{
    public async Task<LoginReply> Login(string username, string password)
    {
        string loginServiceUrl = Environment.GetEnvironmentVariable(ApiConstants.LOGIN_SERVICE_URL);

        using GrpcChannel channel = GrpcChannel.ForAddress(loginServiceUrl);

        Login.LoginClient client = new(channel);

        LoginRequest request = new() { Username = username, Password = password };

        LoginReply response = await client.LoginAsync(request);

        return response;
    }
}