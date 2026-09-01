namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(@"
         
         ████████╗██╗  ██╗██████╗ ███████╗███████╗███████╗███╗   ███╗ █████╗ ███████╗
         ╚══██╔══╝██║  ██║██╔══██╗██╔════╝██╔════╝██╔════╝████╗ ████║██╔══██╗██╔════╝
            ██║   ███████║██████╔╝█████╗  █████╗  ███████╗██╔████╔██║███████║███████╗
            ██║   ██╔══██║██╔══██╗██╔══╝  ██╔══╝  ╚════██║██║╚██╔╝██║██╔══██║╚════██║
            ██║   ██║  ██║██║  ██║███████╗███████╗███████║██║ ╚═╝ ██║██║  ██║███████║
            ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝
                                                                                
                    ██████╗██╗  ██╗ █████╗ ██████╗  █████╗ ██████╗ ███████╗
                   ██╔════╝██║  ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝
                   ██║     ███████║███████║██████╔╝███████║██║  ██║█████╗  
                   ██║     ██╔══██║██╔══██║██╔══██╗██╔══██║██║  ██║██╔══╝  
                   ╚██████╗██║  ██║██║  ██║██║  ██║██║  ██║██████╔╝███████╗
                    ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝
");
                Console.ResetColor();
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Exit");
                Console.Write("Enter  number of choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter number of choice.");
                    Console.ReadKey();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        CreateTeams();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Online Library. GoodBye!");
                        Console.ReadKey();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void CreateTeams()
        {
            string[,] teams = new string[3, 2];
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("        CREATE TEAMS");
            Console.WriteLine("Instructions: Create 3 teams, consisting of 2 members per team.");
            Console.WriteLine("================================");

            for (int team = 0; team < 3; team++)
            {
                Console.WriteLine();
                Console.WriteLine("TEAM " + (team + 1));

                for (int player = 0; player < 2; player++)
                {
                    while (true)
                    {
                        Console.Write("Enter Player " + (player + 1) + " name: ");
                        string name = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            teams[team, player] = name;
                            break;
                        }

                        Console.WriteLine("Name cannot be empty.");
                    }
                }
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================================");
            Console.WriteLine("         TEAMS CREATED!");
            Console.WriteLine("================================");
            Console.ResetColor();
            for (int team = 0; team < 3; team++)
            {
                Console.WriteLine();
                Console.WriteLine("TEAM " + (team + 1));
                Console.WriteLine("Player 1: " + teams[team, 0]);
                Console.WriteLine("Player 2: " + teams[team, 1]);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();


            StartGame(teams);
        }

        static void StartGame(string[,] teams)

        {
            List<string> charades = new List<string>
           {
            "Last Christmas",
            "Polar Express",
            "Scrooge",
            "Simbang Gabi",
            "Mistletoe",
            "Feliz Navidad",
            "The Grinch",
            "Nutcracker",
            "Secret Santa",
            "Snow Globe"
             };

        }

    }
}

