namespace BasicLoginPage.Pages;
using Classes;

public partial class AccountPage
{
    public AccountPage(Account User)
    {
        if (User.Register) Register(User);
    }
    
    public static bool Register(Account User)
    {
        return true;
    }
    
    public static bool Login(Account User)
    {
        return true;
    }
}