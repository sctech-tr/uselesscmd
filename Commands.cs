namespace theuselesscmd;

public static class Commands
{
    private static readonly string PasswordFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".theuselesscmdrc");

    private static string? _password;

    // Load password from file if it exists
    static Commands()
    {
        if (File.Exists(PasswordFilePath))
        {
            _password = File.ReadAllText(PasswordFilePath);
        }
    }

    public static bool IsPasswordProtected => _password != null;

    public static bool ValidatePassword(string input)
    {
        return input == _password;
    }

    public static void PassNoParam()
    {
        Console.WriteLine("pass - a utility for managing theuselesscmd passwords");
        Console.WriteLine("pass set - change or set the password");
        Console.WriteLine("pass rm - remove the password");
    }
    
    public static void SetPassword()
    {
        Console.Write("enter a new password: ");
        _password = Console.ReadLine();
        
        File.WriteAllText(PasswordFilePath, _password!);
        Console.WriteLine("password has been set and saved.");
    }

    public static void RemovePassword()
    {
        _password = null;
        
        if (File.Exists(PasswordFilePath))
        {
            File.Delete(PasswordFilePath);
        }
        Console.WriteLine("password has been removed.");
    }

    public static void IpAddress()
    {
        Console.WriteLine("IPv4: 127.0.0.1 IPv6: ::1");
    }

    public static void GetDateTime()
    {
        Console.WriteLine($"current datetime: {DateTime.Now.AddYears(1000)}");
    }

    public static void Magic8Ball()
    {
        string[] responses = { 
            "yes!", 
            "no.", 
            "maybe?", 
            "ask again later.", 
            "go away", 
            "idk", 
            "never gonna give you up", 
            "ayyıldızlıkırmızıbayraktaşıyankahramanoğullarındangillersizleştiricileştireveremeyebileceklerimizdenmişsinizcesinedir", 
            "sudo rm -rf /*", 
            "deleting system32...", 
            "U+200C", 
            "yesyesyesyesyesyesyesyesNO"};
        Random random = new Random();
        Console.WriteLine(responses[random.Next(responses.Length)]);
    }

    public static void ShutUp()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "shutup.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Critical Unknown IOError: {filePath} is missing");
            return;
        }

        // Read the file content
        string longWord = File.ReadAllText(filePath);

        if (longWord.Length != 189819)
        {
            Console.WriteLine("warning: the string in shutup.txt is not exactly 191,664 characters long!");
        }

        Console.WriteLine("your fine for being rude is-");
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.WriteLine("A 191,664 CHAR STRING!");
        Console.WriteLine("prepare yourself >:D");
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.WriteLine(longWord);
    }
    
    public static void RollDice()
    {
        Random random = new Random();
        int roll = random.Next(1, 7);
        Console.WriteLine($"{roll}");
    }
    
    public static void SelfDestruct()
    {
        Console.WriteLine("critical warning: self-destruct sequence activated! there isn't a report associated with this event.");
        for (int i = 10; i >= 1; i--)
        {
            Thread.Sleep(500);
            Console.WriteLine($"{i}...");
        }
        Console.WriteLine("self-destruct deactivated. reported reason: it was a joke lol");
    }
    
    public static void Fortune()
    {
        string[] fortunes = { "you will find a penny on the ground today.", "beware of coding bugs tomorrow.", "an unexpected error will bring great wisdom.", "today is the day to ignore deadlines.", "you will forget your password when you need it most." };
        Random random = new Random();
        Console.WriteLine(fortunes[random.Next(fortunes.Length)]);
    }
    
    public static void TellAJoke()
    {
        string[] jokes = {
            // TODO: add more jokes
            "why do programmers hate nature? it has too many bugs.",
            "how many programmers does it take to change a light bulb? none, that's a hardware problem!",
            "why do java developers wear glasses? because they don’t C#.",
            "i told my computer i needed a break, and now it won’t stop sending me ads for vacations."
        };
        Random random = new Random();
        Console.WriteLine(jokes[random.Next(jokes.Length)]);
    }
    
    public static void Lag()
    {
        Console.Write("processing");
        for (int i = 0; i < 20; i++) // if you want it to be more evil, increase 20
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        Console.WriteLine("nothing was happening");
    }
    
    public static void UselessFact()
    {
        string[] facts = {
            "bananas are berries, but strawberries aren’t.",
            "wombat poop is cube-shaped.",
            "there is a species of jellyfish that is immortal.",
            "ketchup was sold as medicine in the 1830s.",
            "octopuses have three hearts."
        };
        Random random = new Random();
        Console.WriteLine(facts[random.Next(facts.Length)]);
    }
    
    public static void PrintUnicodeChar()
    {
        Random random = new Random();
        int unicodeIndex = random.Next(0x2000, 0x3000);  // Random Unicode block
        char unicodeChar = (char)unicodeIndex;
        Console.WriteLine($"here’s a random unicode character: {unicodeChar}");
    }
    public static void UnknownCommand()
    {
        Console.WriteLine("list of commands:");
        Console.WriteLine("ip - get ip address");
        Console.WriteLine("datetime - get date time");
        Console.WriteLine("magic8ball - a magic8ball");
        Console.WriteLine("shutup - make theuselesscmd shut up");
        Console.WriteLine("pass - password management utility (probably the most useful command)");
        Console.WriteLine("dice - roll a dice");
        Console.WriteLine("sd - self destruct");
        Console.WriteLine("fortune - fortune cookie");
        Console.WriteLine("tellajoke - tell a joke");
        Console.WriteLine("lag - process some REALLY important info");
        Console.WriteLine("facts - a random useless fact");
        Console.WriteLine("");
        
    }
}