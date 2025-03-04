using System;

namespace Bowlinghall
{
    public class MatchSimulation
    {
        private static Random _random = new Random();
        public const int TotalRounds = 5;

        public static void SimulateMatch(Player player1, Player player2, ILogger logger)
        {
            Console.WriteLine($"Simulating match between {player1.Name} and {player2.Name}");
            logger.Log($"Simulating match between {player1.Name} and {player2.Name}");

            for (int round = 1; round <= TotalRounds; round++)
            {
                Console.WriteLine($"Round {round}");

                int score1 = _random.Next(0, 11);
                int score2 = _random.Next(0, 11);

                player1.Score += score1;
                player2.Score += score2;

                Console.WriteLine($"{player1.Name} score: {score1}");
                logger.Log($"{player1.Name} score: {score1}");

                Console.WriteLine($"{player2.Name} score: {score2}");
                logger.Log($"{player2.Name} score: {score2}");

                if (score1 > score2)
                {
                    Console.WriteLine($"Winner of Round {round}: {player1.Name}");
                    logger.Log($"Winner of Round {round}: {player1.Name}");
                }
                else if (score2 > score1)
                {
                    Console.WriteLine($"Winner of Round {round}: {player2.Name}");
                    logger.Log($"Winner of Round {round}: {player2.Name}");
                }
                else
                {
                    Console.WriteLine($"Draw in Round {round}");
                    logger.Log($"Draw in Round {round}");
                }
            }

            Console.WriteLine($"Final score: {player1.Name} {player1.Score} - {player2.Name} {player2.Score}");
            logger.Log($"Final score: {player1.Name} {player1.Score} - {player2.Name} {player2.Score}");

            if (player1.Score > player2.Score)
            {
                Console.WriteLine($"Match Winner: {player1.Name}");
                logger.Log($"Match Winner: {player1.Name}");
            }
            else if (player2.Score > player1.Score)
            {
                Console.WriteLine($"Match Winner: {player2.Name}");
                logger.Log($"Match Winner: {player2.Name}");
            }
            else
            {
                Console.WriteLine("Match Draw");
                logger.Log("Match Draw");
            }
        }
    }
}

