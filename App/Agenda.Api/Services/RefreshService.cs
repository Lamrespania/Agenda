namespace Agenda.Api.Services;

public class RefreshService
{
    public async Task<RefreshReply> Refresh(string username, string refreshToken)
    {
        string loginServiceUrl = Environment.GetEnvironmentVariable(ApiConstants.LOGIN_SERVICE_URL);

        using GrpcChannel channel = GrpcChannel.ForAddress(loginServiceUrl);

        Refresh.RefreshClient client = new(channel);

        RefreshRequest request = new() { Username = username, RefreshToken = refreshToken };

        RefreshReply response = await client.RefreshAsync(request);

        return response;
    }
}