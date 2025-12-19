using System.Security.Cryptography;

namespace Tasker.Helper;

public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100_000;

    private static readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA256;

    public static string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, HashSize);

        return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string passwordHash)
    {
        string[] passwordHashSplitted = passwordHash.Split('.', 3);

        byte[] salt = Convert.FromBase64String(passwordHashSplitted[0]);
        byte[] hash = Convert.FromBase64String(passwordHashSplitted[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}
