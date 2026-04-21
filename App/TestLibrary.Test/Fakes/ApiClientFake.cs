namespace TestLibrary.Test;

public class ApiClientFake : IApiClient
{
    private readonly Random _random = new();

    public async Task<uint> GetRandomFrom0To10()
    {
        return await Task.FromResult((uint)_random.Next(0, 10));
    }

    public async Task<uint> GetRandomFrom11To99()
    {
        return await Task.FromResult((uint)_random.Next(11, 99));
    }
}