using System.Security.Cryptography;
using BasicLoginPage.Classes.Json;

namespace BasicLoginPage.Classes.Cryptography;

public abstract class HashPassword
{

    public static HashSaltPair Hash(string Password)
    {
        byte[] Salt = new byte[64];
        
        RandomNumberGenerator Rng = RandomNumberGenerator.Create();
        {
            Rng.GetBytes(Salt);
        }

        const short Iterations = 15000;

        byte[] HashedPassword;

        try
        {
            Rfc2898DeriveBytes Rfc = new(Password, Salt, Iterations);
            byte[] Hash = Rfc.GetBytes(64);
            HashedPassword = Rfc2898DeriveBytes.Pbkdf2(Hash, Salt, Iterations, HashAlgorithmName.SHA512, 1024);
        }
        catch (Exception Exc)
        {
            throw new Exception("Error Hashing Password\n", Exc);
        }
        
        string HashedPasswordString = Convert.ToBase64String(HashedPassword);
        string SaltString = Convert.ToBase64String(Salt);
        
        return new HashSaltPair(HashedPasswordString, SaltString);
    }

    public static HashSaltPair Hash(string Password, string Salt)
    {
        byte[] SaltBytes = Convert.FromBase64String(Salt);
        
        const short Iterations = 15000;
        
        byte[] HashedPassword;

        try
        {
            Rfc2898DeriveBytes Rfc = new(Password, SaltBytes, Iterations);
            byte[] Hash = Rfc.GetBytes(64);
            HashedPassword = Rfc2898DeriveBytes.Pbkdf2(Hash, SaltBytes, Iterations, HashAlgorithmName.SHA512, 1024);
        }
        catch (Exception Exc)
        {
            throw new Exception("Error Hashing Password\n", Exc);
        }
        
        string HashedPasswordString = Convert.ToBase64String(HashedPassword);
        return new HashSaltPair(HashedPasswordString, Salt);
    }
}