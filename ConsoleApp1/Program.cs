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

            int[] scores = new int[3];

            List<int> teamOrder = new List<int> { 0, 1, 2 };

            Random random = new Random();

            for (int i = teamOrder.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                int temp = teamOrder[i];
                teamOrder[i] = teamOrder[j];
                teamOrder[j] = temp;
            }

            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("        RANDOM TEAM ORDER");
            Console.WriteLine("================================");

            Console.WriteLine();
            Console.WriteLine("First:  Team " + (teamOrder[0] + 1));
            Console.WriteLine("Second: Team " + (teamOrder[1] + 1));
            Console.WriteLine("Third:  Team " + (teamOrder[2] + 1));

            Console.WriteLine();
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            // Teams take their turn
            for (int i = 0; i < teamOrder.Count; i++)
            {
                int team = teamOrder[i];

                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("             TURN");
                Console.WriteLine("================================");

                Console.WriteLine();
                Console.WriteLine("TEAM " + (team + 1));

                Console.WriteLine("Player 1: " + teams[team, 0]);
                Console.WriteLine("Player 2: " + teams[team, 1]);

                Console.WriteLine();
                Console.WriteLine("Press any key to reveal the charade...");
                Console.ReadKey();

                int randomIndex = random.Next(charades.Count);

                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("          YOUR CHARADE");
                Console.WriteLine("================================");

                Console.WriteLine();
                Console.WriteLine(charades[randomIndex]);

                Console.WriteLine();
                Console.WriteLine("Act it out!");

                Console.WriteLine();
                Console.WriteLine("Press any key when finished...");
                Console.ReadKey();

                // Scoring
                // Scoring
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("================================");
                    Console.WriteLine("            RESULT");
                    Console.WriteLine("================================");

                    Console.WriteLine();
                    Console.WriteLine("Was the charade guessed?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");

                    Console.WriteLine();
                    Console.Write("Enter choice: ");

                    string guessInput = Console.ReadLine();

                    if (!int.TryParse(guessInput, out int guessChoice))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter 1 or 2.");
                        Console.ReadKey();
                        continue;
                    }

                    if (guessChoice == 1)
                    {
                        scores[team]++;

                        Console.WriteLine();
                        Console.WriteLine("Correct!");
                        Console.WriteLine("Team " + (team + 1) + " gets +1 point!");
                        Console.ReadKey();
                        break;
                    }
                    else if (guessChoice == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Not guessed.");
                        Console.WriteLine("No points awarded.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        Thread.Sleep(1200);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Current Score:");
                Console.WriteLine("Team 1: " + scores[0]);
                Console.WriteLine("Team 2: " + scores[1]);
                Console.WriteLine("Team 3: " + scores[2]);

                Console.WriteLine();
                Console.WriteLine("Press any key for the next team...");
                Console.ReadKey();
            }
        }
    }
}
