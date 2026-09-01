using System.Threading;
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
                Console.WriteLine("2. Instructions");
                Console.WriteLine("3. Exit");

                Console.Write("Enter number of choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a number.");
                    Thread.Sleep(1200);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateTeams();
                        break;


                    case 2:
                        Infos();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Thank you for playing ThreesMasCharade. Goodbye!");
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
        static void Infos()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("========================================");
            Console.WriteLine("         GAME INSTRUCTIONS ");
            Console.WriteLine("========================================");

            Console.ResetColor();

            Console.WriteLine(@"
HOW TO PLAY
----------------------------------------
1. The game consists of 3 teams. 
   Each team has 2 players.
2. Teams will be randomly selected to
   determine the playing order.
3. A Christmas-related word or phrase
   will be shown to the team.
4. One player acts out the charade while
   the other players try to guess it.
5. After acting, select whether the
   charade was guessed or not.
6.  A referee will be assigned to 
    oversee the game.

SCORING
----------------------------------------
• Correct Guess  = +1 Point
• First Team to reach 10 Points Wins!

 POWER-UPS
----------------------------------------
• Double Points
  A correct answer gives +2 points.

• Second Chance
  Get another charade if the first one was not guessed.

• Freeze
  The next team must skip their turn.

========================================

Press any key to return to the menu.
");
            Console.ReadKey();
        }

        static void CreateTeams()
        {
            string[,] teams = new string[3, 2];

            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("          CREATE TEAMS");
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
            Console.WriteLine("Press any key to start the game.");
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
                "Snow Globe",

                "Home Alone",
                "Jingle Bells",
                "Santa Claus",
                "Noche Buena",
                "Christmas Caroling",
                "Rudolph",
                "Gift Wrapping",
                "Parol",
                "Jack Frost",
                "Christmas Tree"
            };
            List<int> guessedCharades = new List<int>();
            string[] powerUps =
            {
                "Double Points",
                "Second Chance",
                "Freeze"
            };
            int[] scores = new int[3];
            Random random = new Random();
            bool freezeActive = false;
            List<int> teamOrder = new List<int>
            {
                0,
                1,
                2
            };

            for (int i = teamOrder.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                int temp = teamOrder[i];
                teamOrder[i] = teamOrder[j];
                teamOrder[j] = temp;
            }

            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("       RANDOM TEAM ORDER");
            Console.WriteLine("================================");

            Console.WriteLine();

            Console.WriteLine("First:  Team " + (teamOrder[0] + 1));
            Console.WriteLine("Second: Team " + (teamOrder[1] + 1));
            Console.WriteLine("Third:  Team " + (teamOrder[2] + 1));

            Console.WriteLine();
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey();

            while (true)
            {
                for (int i = 0; i < teamOrder.Count; i++)
                {
                    int team = teamOrder[i];


                    if (freezeActive)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine("================================");
                        Console.WriteLine("          ❄ FROZEN!");
                        Console.WriteLine("================================");

                        Console.ResetColor();

                        Console.WriteLine();
                        Console.WriteLine("Uh - Oh! Santa Hit the Freeze Button!");
                        Console.WriteLine("Team " + (team + 1) + " has been frozen!");
                        Console.WriteLine();
                        Console.WriteLine("❄️ Better luck next round!");

                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                        freezeActive = false;
                        continue;
                    }

                  
                    Console.Clear();

                    Console.WriteLine("================================");
                    Console.WriteLine("            TEAM " + (team + 1));
                    Console.WriteLine("================================");

                    Console.WriteLine();

                    Console.WriteLine("Player 1: " + teams[team, 0]);
                    Console.WriteLine("Player 2: " + teams[team, 1]);

                    Console.WriteLine();
                    Console.WriteLine("Current Score: " + scores[team]);

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();

                    bool hasPowerUp = false;
                    string currentPowerUp = "";

                    int powerUpChance = random.Next(1, 101);

                    if (powerUpChance <= 30)
                    {
                        hasPowerUp = true;

                        int powerUpIndex = random.Next(powerUps.Length);

                        currentPowerUp = powerUps[powerUpIndex];

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("================================");
                        Console.WriteLine("        POWER-UP APPEARED!");
                        Console.WriteLine("================================");

                        Console.ResetColor();

                        Console.WriteLine();

                        Console.WriteLine("Team " + (team + 1) + " received:");

                        Console.WriteLine();
                        Console.WriteLine(currentPowerUp);

                        Console.WriteLine();
                        Console.WriteLine("Use this power-up?");

                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");

                        bool usePowerUp = false;

                        while (true)
                        {
                            Console.WriteLine();
                            Console.Write("Enter choice: ");

                            string powerInput = Console.ReadLine();

                            if (!int.TryParse(powerInput, out int powerChoice))
                            {
                                Console.WriteLine("Please enter a number.");
                                continue;
                            }

                            if (powerChoice == 1)
                            {
                                usePowerUp = true;
                                break;
                            }
                            else if (powerChoice == 2)
                            {
                                usePowerUp = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid number choice. Please enter 1 or 2.");
                            }
                        }

                        if (usePowerUp)
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("================================");
                            Console.WriteLine("       POWER-UP ACTIVATED!");
                            Console.WriteLine("================================");

                            Console.ResetColor();

                            Console.WriteLine();
                            Console.WriteLine("Here comes Santa Claus!");
                            Console.WriteLine("Here comes Santa Claus!");
                            Console.WriteLine();
                            Console.WriteLine(currentPowerUp);
                            if (currentPowerUp == "Double Points")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Correct answer = +2 points!");
                            }

                            if (currentPowerUp == "Second Chance")
                            {
                                Console.WriteLine();
                                Console.WriteLine("If you fail, you get another charade!");
                            }

                            if (currentPowerUp == "Freeze")
                            {
                                freezeActive = true;

                                Console.WriteLine();
                                Console.WriteLine(" The NEXT team will be frozen!");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Power-up was not used.");

                            hasPowerUp = false;

                            Console.WriteLine();
                            Thread.Sleep(1300);
                            Console.ReadKey();
                        }
                    }

               
                    int randomIndex;

                    while (true)
                    {
                        randomIndex = random.Next(charades.Count);

                        if (!guessedCharades.Contains(randomIndex))
                        {
                            break;
                        }
                    }

                    string currentCharade = charades[randomIndex];

                    Console.Clear();

                    Console.WriteLine("================================");
                    Console.WriteLine("          YOUR CHARADE");
                    Console.WriteLine("================================");

                    Console.WriteLine();

                    Console.WriteLine("TEAM " + (team + 1));

                    Console.WriteLine();
                    Console.WriteLine("Charade:");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(currentCharade);
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.WriteLine("Act it out!");

                    Console.WriteLine();
                    Console.WriteLine("Press any key when finished.");
                    Console.ReadKey();
                    bool guessed = false;

                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("================================");
                        Console.WriteLine("            RESULT");
                        Console.WriteLine("================================");

                        Console.WriteLine();
                        Console.WriteLine("Was the charade guessed?");

                        Console.WriteLine();
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");

                        Console.WriteLine();
                        Console.Write("Enter choice: ");

                        string guessInput = Console.ReadLine();

                        if (!int.TryParse(guessInput, out int guessChoice))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a number.");
                            Thread.Sleep(1300);
                            continue;
                        }

                        if (guessChoice == 1)
                        {
                            guessed = true;
                            break;
                        }
                        else if (guessChoice == 2)
                        {
                            guessed = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid number choice. Please enter 1 or 2.");
                            Thread.Sleep(1300);

                        }
                    }

                  

                    if (!guessed &&
                        hasPowerUp &&
                        currentPowerUp == "Second Chance")
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("================================");
                        Console.WriteLine("        SECOND CHANCE!");
                        Console.WriteLine("================================");

                        Console.ResetColor();

                        Console.WriteLine();
                        Console.WriteLine("You get another charade!");

                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                        while (true)
                        {
                            randomIndex = random.Next(charades.Count);

                            if (!guessedCharades.Contains(randomIndex))
                            {
                                break;
                            }
                        }

                        currentCharade = charades[randomIndex];

                  
                        Console.Clear();

                        Console.WriteLine("================================");
                        Console.WriteLine("        SECOND CHANCE");
                        Console.WriteLine("================================");

                        Console.WriteLine();

                        Console.WriteLine("Charade:");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(currentCharade);
                        Console.ResetColor();

                        Console.WriteLine();
                        Console.WriteLine("Act it out!");

                        Console.WriteLine();
                        Console.WriteLine("Press any key when finished.");
                        Console.ReadKey();

                      

                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("================================");
                            Console.WriteLine("            RESULT");
                            Console.WriteLine("================================");

                            Console.WriteLine();
                            Console.WriteLine("Was the second charade guessed?");

                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");

                            Console.WriteLine();
                            Console.Write("Enter choice: ");

                            string secondInput = Console.ReadLine();

                            if (!int.TryParse(secondInput, out int secondChoice))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Please enter a number.");
                                Thread.Sleep(1300);
                                continue;
                            }

                            if (secondChoice == 1)
                            {
                                guessed = true;
                                break;
                            }
                            else if (secondChoice == 2)
                            {
                                guessed = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid number choice. Please enter 1 or 2.");
                                Thread.Sleep(1300);

                            }
                        }
                    }

                  
                    Console.Clear();

                    if (guessed)
                    {
                      
                        guessedCharades.Add(randomIndex);

                        if (hasPowerUp &&
                            currentPowerUp == "Double Points")
                        {
                            scores[team] += 2;

                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine(" DOUBLE POINTS!");

                            Console.ResetColor();

                            Console.WriteLine();
                            Console.WriteLine("Team " + (team + 1) + " gets +2 points!");
                        }
                        else
                        {
                            
                            scores[team]++;

                            Console.WriteLine("Correct!");

                            Console.WriteLine();
                            Console.WriteLine("Team " + (team + 1) + " gets +1 point!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The charade was not guessed.");
                        Console.WriteLine();
                        Console.WriteLine("No points awarded.");
                    }

                   
                    Console.WriteLine();

                    Console.WriteLine("================================");
                    Console.WriteLine("          CURRENT SCORE");
                    Console.WriteLine("================================");

                    Console.WriteLine();

                    Console.WriteLine("Team 1: " + scores[0]);
                    Console.WriteLine("Team 2: " + scores[1]);
                    Console.WriteLine("Team 3: " + scores[2]);

                    
                    if (scores[team] >= 6)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("================================");
                        Console.WriteLine("         WE HAVE A WINNER!");
                        Console.WriteLine("================================");

                        Console.ResetColor();

                        Console.WriteLine();

                        Console.WriteLine("TEAM " + (team + 1) + " WINS!");

                        Console.WriteLine();
                        Console.WriteLine("Winning Score: " + scores[team]);

                        Console.WriteLine();

                        Console.WriteLine("Final Scores:");
                        Console.WriteLine("Team 1: " + scores[0]);
                        Console.WriteLine("Team 2: " + scores[1]);
                        Console.WriteLine("Team 3: " + scores[2]);

                        Console.WriteLine();
                        Console.WriteLine("Congratulations Team " + (team + 1) + "!");

                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();

                        return;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Proceeding to the  next team.");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
