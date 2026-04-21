namespace TestLibrary;

public class RandomService
{
    private readonly Random _random;

    public RandomService()
    {
        _random = new();
    }

    public RandomService(int seed)
    {
        _random = new(seed);
    }

    /// <summary>
    /// Get a random number from 0 to 10.
    /// </summary>
    public uint GetRandomFrom0To10()
    {
        return (uint)_random.Next(0, 10);
    }

    /// <summary>
    /// Get a random number from 11 to 99.
    /// </summary>
    public uint GetRandomFrom11To99()
    {
        return (uint)_random.Next(11, 99);
    }
}