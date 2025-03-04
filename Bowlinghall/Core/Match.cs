using System;

namespace Bowlinghall
{
    public class Match
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public Player Winner { get; set; }


        public Match(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            Score1 = 0;
            Score2 = 0;
        }
    }
}
