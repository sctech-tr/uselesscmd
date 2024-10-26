using System.Net.Mail;
using System.Net.Mime;

namespace theuselesscmd;

class Program
{
    static void Main()
    {
        Console.WriteLine("welcome to theuselesscmd!");
        // Password validation if password is set
        if (Commands.IsPasswordProtected)
        {
            Console.Write("enter password to continue: ");
            string? inputPassword = Console.ReadLine();

            if (inputPassword != null && !Commands.ValidatePassword(inputPassword))
            {
                Console.WriteLine("incorrect password! access denied.");
                Environment.Exit(1);
            }
                
            Console.WriteLine("access granted.");
        }
        else
        {
            Console.WriteLine("no password set. Use 'pass set' to set one.");
        }
        
        Console.WriteLine("type 'idk' for a list of commands."); // not a command, but it still triggers Commands.UnknownCommand
        
        while (true)
        {
            // Main command loop
            Console.Write($"\n{System.Environment.UserName}@{System.Environment.MachineName} $ ");
            string command = Console.ReadLine();
            
            switch (command)
            {
                case "ip":
                    Commands.IpAddress();
                    break;

                case "datetime":
                    Commands.GetDateTime();
                    break;

                case "magic8ball":
                    Commands.Magic8Ball();
                    break;

                case "shutup":
                    Commands.ShutUp();
                    break;

                case "pass set":
                    Commands.SetPassword();
                    break;

                case "pass rm":
                    Commands.RemovePassword();
                    break;

                case "pass":
                    Commands.PassNoParam();
                    break;
                
                case "dice":
                    Commands.RollDice();
                    break;
                
                case "sd":
                    Commands.SelfDestruct();
                    break;
                
                case "fortune":
                    Commands.Fortune();
                    break;
                
                case "tellajoke":
                    Commands.TellAJoke();
                    break;
                
                case "lag":
                    Commands.Lag();
                    break;
                
                case "facts":
                    Commands.UselessFact();
                    break;
                
                case "unicode":
                    Commands.PrintUnicodeChar();
                    break;
                
                case "exit":
                    Console.WriteLine("goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Commands.UnknownCommand();
                    break;
            }
        }
    }
}