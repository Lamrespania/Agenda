namespace TestLibrary;

public class RandomApiService(IApiClient apiClient)
{
    private readonly IApiClient _apiClient = apiClient;

    public async Task<uint> GetRandomFrom0To10()
    {
        return await _apiClient.GetRandomFrom0To10();
    }

    public async Task<uint> GetRandomFrom11To99()
    {
        return await _apiClient.GetRandomFrom11To99();
    }
}