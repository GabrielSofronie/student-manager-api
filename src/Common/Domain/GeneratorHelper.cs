using System.Security.Cryptography;
using System.Text;

namespace Domain;

public static class GeneratorHelper
{
    private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public static string NewCode(byte length = 10)
    {
        var code = string.Empty;
        for (var i = 0; i < length; i++)
        {
            string character;
            do
            {
                var index = new Random().Next(0, alphabet.Length);
                character = alphabet.ToCharArray()[index].ToString();
            }
            while (code.IndexOf(character) != -1);

            code += character;
        }

        return code.ToUpper();
    }

    public static Guid NewGuid(string value)
    {
        using var md5Hasher = MD5.Create();
        var hash = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));

        return new Guid(hash);
    }
}