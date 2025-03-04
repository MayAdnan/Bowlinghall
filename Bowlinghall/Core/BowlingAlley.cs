using System;
using System.Collections.Generic;

namespace Bowlinghall
{
    //Facade
    public class BowlingAlley
    {
        private List<Player> players = new List<Player>();
        private ILogger _logger;
        public BowlingAlley()
        {
            players = FileHandler.LoadPlayers();
            _logger = MatchLogger.GetInstance();
        }

        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Add a new player");
                Console.WriteLine("3. Close");
                Console.Write("Enter the corresponding number: ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        AddNewPlayer();
                        break;
                    case "3":
                        Console.WriteLine("Closing...");
                        _logger.Log("The application has been closed.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        _logger.Log("Invalid input entered.");
                        break;
                }

            }
        }
        public void PlayGame()
        {
            var players = FileHandler.LoadPlayers();
            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

            Console.WriteLine("\n Match started ");
            _logger.Log("Match has started.");

            Console.Write("Enter player1 name: ");
            string player1Name = Console.ReadLine();

            Player player1 = players.Find(p => p.Name == player1Name);
            if (player1 == null)
            {
                Console.WriteLine($"Player {player1Name} not found.");
                _logger.Log($"Player {player1Name} not found.");
                return;
            }

            Console.WriteLine("Enter player2 name: ");
            string player2Name = Console.ReadLine();

            Player player2 = players.Find(p => p.Name == player2Name);
            if (player2 == null)
            {
                Console.WriteLine($"Player {player2Name} not found.");
                _logger.Log($"Player {player2Name} not found.");
                return;
            }

            MatchSimulation.SimulateMatch(player1, player2, _logger);

            FileHandler.LoadPlayers();
        
            player1.ResetScore();
            player2.ResetScore();

            Console.WriteLine("Match ended. Press any key to exit.");
            _logger.Log("Match ended.");
            Console.ReadKey();
        }

        private void AddNewPlayer()
        {
            Console.Write("Enter new player name: ");
            string playerName = Console.ReadLine();

            Player newPlayer = PlayerFactory.CreatePlayer(playerName);
            FileHandler.AddPlayer(newPlayer);

            Console.WriteLine($"Player {playerName} has been added.");
            _logger.Log($"Player {playerName} has been added.");
        }
    }
}
