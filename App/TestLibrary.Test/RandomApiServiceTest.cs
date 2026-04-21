namespace TestLibrary.Test;

public class RandomApiServiceTest
{
    private readonly RandomApiService _randomApiService;

    public RandomApiServiceTest()
    {
        IApiClient apiClientFake = new ApiClientFake();

        _randomApiService = new(apiClientFake);
    }

    [Fact]
    public async Task GetRandomFrom0To10_ReturnUintFrom0To10()
    {
        for (int randomTry = 0; randomTry < 100; randomTry++)
        {
            uint randomNumber = await _randomApiService.GetRandomFrom0To10();

            Assert.InRange<uint>(randomNumber, 0, 10);
        }
    }

    [Fact]
    public async Task GetRandomFrom11To99_ReturnUintFrom11To99()
    {
        for (int randomTry = 0; randomTry < 100; randomTry++)
        {
            uint randomNumber = await _randomApiService.GetRandomFrom11To99();

            Assert.InRange<uint>(randomNumber, 11, 99);
        }
    }
}