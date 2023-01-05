using System.Text.Json;
namespace BasicLoginPage.Classes.Json;

public class UserStorage
{
    private static readonly List<string> Usernames = GetUsernames();
    private static string JsonPath = "./Users.json";

    protected internal static readonly List<Account> UserLogins = JsonSerializer.Deserialize<List<Account>>(File.ReadAllText(JsonPath)) ?? new List<Account>();
    
    protected internal UserStorage()
    {
    }

    private static List<string> GetUsernames()
    {
       return UserLogins.Select(User => User.Username).ToList();
    }

    public static void AddUser(Account User)
    {
        UserLogins.Add(User);
    }
    
    public static void AddUser(string Username, string HashedPassword, string Salt)
    {
        UserLogins.Add(new Account(Username, HashedPassword, Salt));
    }
    
    public static void RemoveUser(Account User)
    {
        if (UserExists(User)) {
            UserLogins.Remove(User);
            Usernames.Remove(User.Username);
        }
    }
    
    public static bool UserExists(string Username)
    {
        return Usernames.Contains(Username);
    }

    public static bool UserExists(Account User)
    {
        return UserLogins.Contains(User);
    }

    public static void Store()
    {
        
    }
}