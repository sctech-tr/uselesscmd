namespace theuselesscmd;

class Program
{
    static void Main()
    {
        Console.WriteLine("welcome to theuselesscmd!");

        while (true)
        {
            // Password validation if password is set
            if (Commands.IsPasswordProtected)
            {
                Console.Write("enter password to continue: ");
                string? inputPassword = Console.ReadLine();

                if (inputPassword != null && !Commands.ValidatePassword(inputPassword))
                {
                    Console.WriteLine("incorrect password! access denied.");
                    continue;
                }
                
                Console.WriteLine("access granted.");
            }
            else
            {
                Console.WriteLine("no password set. Use 'pass set' to set one.");
            }

            // Main command loop
            Console.WriteLine("type 'idk' for a list of commands."); // not a command, but it still triggers Commands.UnknownCommand
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

                case "exit":
                    Console.WriteLine("goodbye!");
                    return;

                default:
                    Commands.UnknownCommand();
                    break;
            }
        }
    }
}