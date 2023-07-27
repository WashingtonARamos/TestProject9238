using Application.Services.Interfaces;

namespace Application.Services;

public sealed class HashService : IHashService
{
    private static Random? _random;

    private Random Random
    {
        get
        {
            if (_random == null)
            {
                _random = new Random();
            }

            return _random;
        }
    }
    
    public string GetRandomNumberAsString()
    {
        return Random.Next().ToString();
    }

    public string GetHash(string input)
    {
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}