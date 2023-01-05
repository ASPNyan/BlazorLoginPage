namespace BasicLoginPage.Classes;

public class Account
{
    public string Username;
    public string Password;
    public string Salt;
    public bool Register;
    
    public Account(string Username, string Password, string Salt)
    {
        this.Username = Username;
        this.Password = Password;
        this.Salt = Salt;
    }
    
    public Account(string Username, string Password, string Salt, bool Register)
    {
        this.Username = Username;
        this.Password = Password;
        this.Salt = Salt;
        this.Register = Register;
    }

    public static Account Empty()
    {
        return new Account(string.Empty, string.Empty, string.Empty);
    }
}