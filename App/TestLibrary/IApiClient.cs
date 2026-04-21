namespace TestLibrary;

public interface IApiClient
{
    Task<uint> GetRandomFrom0To10();
    Task<uint> GetRandomFrom11To99();
}