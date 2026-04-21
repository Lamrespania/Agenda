namespace Agenda.Common.Helpers;

public static class EnvironmentHelper
{
    private const string WRONG_VALUE_MESSAGE = "Wrong value '{0}' of environment variable '{1}'.";

    /// <summary>
    /// Check if environment variable exists and has a value.
    /// </summary>
    /// <param name="environmentVariable"></param>
    /// <returns>Environment variable parameter.</returns>
    /// <exception cref="Exception">If value is null or empty.</exception>
    public static string CheckEnvVarMissing(this string environmentVariable)
    {
        string environmentVariableValue = Environment.GetEnvironmentVariable(environmentVariable);

        if (string.IsNullOrEmpty(environmentVariableValue))
            throw new Exception($"Environment variable '{environmentVariable}' is missing.");

        return environmentVariable;
    }

    /// <summary>
    /// Check if environment variable value is a valid short.
    /// </summary>
    /// <param name="environmentVariable"></param>
    /// <returns>Environment variable parameter.</returns>
    /// <exception cref="Exception">If value is not a valid short.</exception>
    public static string CheckEnvVarShortValue(this string environmentVariable)
    {
        string environmentVariableValue = Environment.GetEnvironmentVariable(environmentVariable);

        bool validShort = short.TryParse(environmentVariableValue, out _);

        if (validShort == false)
            throw new Exception(string.Format(WRONG_VALUE_MESSAGE, environmentVariableValue, environmentVariable));

        return environmentVariable;
    }

    /// <summary>
    /// Check if environment variable value is a valid url.
    /// </summary>
    /// <param name="environmentVariable"></param>
    /// <returns>Environment variable parameter.</returns>
    /// <exception cref="Exception">If value is not a valid url.</exception>
    public static string CheckUrlFormat(this string environmentVariable)
    {
        string environmentVariableValue = Environment.GetEnvironmentVariable(environmentVariable);

        bool validUri = Uri.TryCreate(environmentVariableValue, UriKind.Absolute, out _);

        if (validUri == false)
            throw new Exception(string.Format(WRONG_VALUE_MESSAGE, environmentVariableValue, environmentVariable));

        return environmentVariable;
    }
}