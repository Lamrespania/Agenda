namespace Agenda.Api.Services;

public class UserService
{
    public async Task<GetReply> Get(int id)
    {
        using GrpcChannel channel = GetChannel();

        Get.GetClient client = new(channel);

        GetRequest request = new() { Id = id };

        GetReply response = await client.GetAsync(request);

        return response;
    }

    public async Task<InsertReply> Insert(string username, string password, UserRole role)
    {
        using GrpcChannel channel = GetChannel();

        Insert.InsertClient client = new(channel);

        InsertRequest request = new() { Username = username, Password = password, Role = (Role)role };

        InsertReply response = await client.InsertAsync(request);

        return response;
    }

    private GrpcChannel GetChannel()
    {
        string userServiceUrl = Environment.GetEnvironmentVariable(ApiConstants.USER_SERVICE_URL);

        return GrpcChannel.ForAddress(userServiceUrl);
    }
}