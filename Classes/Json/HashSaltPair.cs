namespace BasicLoginPage.Classes.Json;

public class HashSaltPair
{
    public HashSaltPair(string Hash, string Salt)
    {
        this.Hash = Hash;
        this.Salt = Salt;
    }

    public string Hash;
    public string Salt;
}