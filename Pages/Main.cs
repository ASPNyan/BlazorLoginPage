namespace BasicLoginPage.Pages;
using Classes;
using Classes.Cryptography;
using Classes.Json;

public partial class Main
{
    private Account User = Account.Empty();
    private bool RegisterSuccess;
    private bool LoginSuccess;

    private void Login()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) return;
        CheckPassword Check = CheckPassword.Check(Username, Password);
        if (!Check.Success) return;
        HashSaltPair HashSaltPair = Check.HashSaltPair;
        User = new Account(Username, HashSaltPair.Hash, HashSaltPair.Salt);
        LoginSuccess = AccountPage.Login(User);
    }

    private void Register()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) return;
        HashSaltPair HashSaltPair = HashPassword.Hash(Password);
        User = new Account(Username, HashSaltPair.Hash, HashSaltPair.Salt, true);
        RegisterSuccess = AccountPage.Register(User);
    }
    
    private void ColourblindnessToggle(int Colourblindness)
    {
        CurrentColourblindness = Colourblindness;
        CoolPrimary = $"var({ColourBlindnessOptions[Colourblindness - 1][0].Key}, {ColourBlindnessOptions[Colourblindness - 1][0].Value})";
        CoolSecondary = $"var({ColourBlindnessOptions[Colourblindness - 1][1].Key}, {ColourBlindnessOptions[Colourblindness - 1][1].Value})";
        WarmPrimary = $"var({ColourBlindnessOptions[Colourblindness - 1][2].Key}, {ColourBlindnessOptions[Colourblindness - 1][2].Value})";
        WarmSecondary = $"var({ColourBlindnessOptions[Colourblindness - 1][3].Key}, {ColourBlindnessOptions[Colourblindness - 1][3].Value})"; 
    }

    private readonly KeyValuePair<string, string>[][] ColourBlindnessOptions =
    {
        new KeyValuePair<string, string>[]
        {
            new ("--Cool-1", "#779cab"),
            new ("--Cool-2", "#30373e"),
            new ("--Warm-1", "#ac7b84"),
            new ("--Warm-2", "#b796ac")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Protanopia-Cool-1", "#8787a7"),
            new ("--Protanopia-Cool-2", "#33333c"),
            new ("--Protanopia-Warm-1", "#969681"),
            new ("--Protanopia-Warm-2", "#a8a8a6")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Protanomaly-Cool-1", "#7d8fa9"),
            new ("--Protanomaly-Cool-2", "#31343d"),
            new ("--Protanomaly-Warm-1", "#a38b82"),
            new ("--Protanomaly-Warm-2", "#b0a0a9")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Deuteranopia-Cool-1", "#8482a6"),
            new ("--Deuteranopia-Cool-2", "#32323b"),
            new ("--Deuteranopia-Warm-1", "#999d81"),
            new ("--Deuteranopia-Warm-2", "#aaada5")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Deuteranomaly-Cool-1", "#7e92a8"),
            new ("--Deuteranomaly-Cool-2", "#31353d"),
            new ("--Deuteranomaly-Warm-1", "#a28782"),
            new ("--Deuteranomaly-Warm-2", "#b09ea8")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Tritanopia-Cool-1", "#78a4a3"),
            new ("--Tritanopia-Cool-2", "#303a3a"),
            new ("--Tritanopia-Warm-1", "#a9807f"),
            new ("--Tritanopia-Warm-2", "#b5a2a1")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Tritanomaly-Cool-1", "#78a0a8"),
            new ("--Tritanomaly-Cool-2", "#30383c"),
            new ("--Tritanomaly-Warm-1", "#aa7d82"),
            new ("--Tritanomaly-Warm-2", "#b59ba7")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Achromatopsia-Cool-1", "#929292"),
            new ("--Achromatopsia-Cool-2", "#353535"),
            new ("--Achromatopsia-Warm-1", "#8a8a8a"),
            new ("--Achromatopsia-Warm-2", "#a2a2a2")
        },
        new KeyValuePair<string, string>[]
        {
            new ("--Achromatomaly-Cool-1", "#86969d"),
            new ("--Achromatomaly-Cool-2", "#333639"),
            new ("--Achromatomaly-Warm-1", "#998387"),
            new ("--Achromatomaly-Warm-2", "#ab9ca6")
        }
    };
}