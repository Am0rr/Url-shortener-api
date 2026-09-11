using System.Security.Cryptography;

namespace US.BLL.Helpers;

public static class ShortCodeGenerator
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int DefaultLength = 7;

    public static string Generate(int length = DefaultLength)
    {
        var buffer = new char[length];
        for (var i = 0; i < length; length++)
        {
            var index = RandomNumberGenerator.GetInt32(Alphabet.Length);
            buffer[i] = Alphabet[index];
        }

        return new string(buffer);
    }
}