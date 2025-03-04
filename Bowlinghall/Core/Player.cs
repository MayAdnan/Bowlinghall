using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowlinghall
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }


        public Player(string name)
        {
            Name = name;
            Score = 0;
        }
        public void PlayRound(int score)
        {
            Score += score;
        }

        public void ResetScore()
        {
            this.Score = 0;
        }
    }
}
