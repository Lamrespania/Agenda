namespace TestLibrary.Test;

public class RandomServiceTest
{
    private readonly RandomService _randomSeedlessService;
    private readonly RandomService _randomSeedService;

    public RandomServiceTest()
    {
        _randomSeedlessService = new();
        _randomSeedService = new(9);
    }

    [Fact]
    public void GetRandomFrom0To10_ReturnUintFrom0To10()
    {
        for (int randomTry = 0; randomTry < 100; randomTry++)
        {
            uint randomNumber = _randomSeedlessService.GetRandomFrom0To10();

            Assert.InRange<uint>(randomNumber, 0, 10);
        }
    }

    [Fact]
    public void GetRandomFrom0To10_WithSeed_ReturnUintFrom0To10()
    {
        uint[] seedResults = [4, 4, 0, 4, 2, 4, 9, 9, 0, 5];

        for (int randomTry = 0; randomTry < 10; randomTry++)
        {
            uint randomNumber = _randomSeedService.GetRandomFrom0To10();

            Assert.InRange<uint>(randomNumber, 0, 10);
            Assert.Equal(seedResults[randomTry], randomNumber);
        }
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 7)]
    [InlineData(3, 2)]
    [InlineData(5, 3)]
    [InlineData(7, 3)]
    [InlineData(9, 4)]
    public void GetRandomFrom0To10_WithGivenSeed_ReturnUintFrom0To10(int seed, uint expectedRandom)
    {
        RandomService randomSeedService = new(seed);

        uint randomNumber = randomSeedService.GetRandomFrom0To10();

        Assert.Equal(expectedRandom, randomNumber);
    }

    [Fact]
    public void GetRandomFrom11To99_ReturnUintFrom11To99()
    {
        for (int randomTry = 0; randomTry < 100; randomTry++)
        {
            uint randomNumber = _randomSeedlessService.GetRandomFrom11To99();

            Assert.InRange<uint>(randomNumber, 11, 99);
        }
    }

    [Fact]
    public void GetRandomFrom11To99_WithSeed_ReturnUintFrom11To99()
    {
        uint[] seedResults = [48, 51, 16, 53, 34, 48, 93, 95, 19, 63];

        for (int randomTry = 0; randomTry < 10; randomTry++)
        {
            uint randomNumber = _randomSeedService.GetRandomFrom11To99();

            Assert.InRange<uint>(randomNumber, 11, 99);
            Assert.Equal(seedResults[randomTry], randomNumber);
        }
    }

    [Theory]
    [InlineData(1, 32)]
    [InlineData(2, 78)]
    [InlineData(3, 36)]
    [InlineData(5, 40)]
    [InlineData(7, 44)]
    [InlineData(9, 48)]
    public void GetRandomFrom11To99_WithGivenSeed_ReturnUintFrom11To99(int seed, uint expectedRandom)
    {
        RandomService randomSeedService = new(seed);

        uint randomNumber = randomSeedService.GetRandomFrom11To99();

        Assert.Equal(expectedRandom, randomNumber);
    }
}