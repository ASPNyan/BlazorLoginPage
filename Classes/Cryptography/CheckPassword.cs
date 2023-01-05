using BasicLoginPage.Classes.Json;

namespace BasicLoginPage.Classes.Cryptography;

public class CheckPassword
{
    public bool Success;
    public HashSaltPair HashSaltPair;
    
    private CheckPassword(bool Success)
    {
        this.Success = Success;
        HashSaltPair = new HashSaltPair("", "");
    }

    private CheckPassword(bool Success, HashSaltPair HashSaltPair)
    {
        this.Success = Success;
        this.HashSaltPair = HashSaltPair;
    }
    
    public static CheckPassword Check(string Username, string Password)
    {
        HashSaltPair? HashSaltPair = GetHashSaltPair(Username);
        if (HashSaltPair == null) return new CheckPassword(false);
        
        string StoredHash = HashSaltPair.Hash;
        string Salt = HashSaltPair.Salt;
        
        HashSaltPair HashSaltPairOutput = HashPassword.Hash(Password, Salt);

        return new CheckPassword(HashSaltPairOutput.Hash == StoredHash, HashSaltPairOutput);
    }

    private static HashSaltPair? GetHashSaltPair(string Username)
    {
        return UserStorage.UserLogins.TakeWhile(Account => Account.Username.Equals(Username)).Select(Account => new HashSaltPair(Account.Password, Account.Salt)).FirstOrDefault();
    }
}