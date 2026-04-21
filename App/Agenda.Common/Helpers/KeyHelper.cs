namespace Agenda.Common.Helpers;

public class KeyHelper
{
    /// <summary>
    /// Get RsaSecurityKey for JWT bearer configuration.
    /// </summary>
    public static RsaSecurityKey GetKey(string keyPath)
    {
        string key = File.ReadAllText(keyPath);

        RSA rsa = RSA.Create();
        rsa.ImportFromPem(key);

        return new RsaSecurityKey(rsa);
    }
}