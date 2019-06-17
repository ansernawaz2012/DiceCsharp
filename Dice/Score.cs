using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Score
    {

        public Player CheckDiceScore(Player player, int diceScore)
        {


            if (diceScore == 1)
            {
                player.GameLost = true;
                return player;
            }

            player.Score += diceScore;


            if (player.Score >= 20)
            {
                player.GameWon = true;
            }
            

            return player;
        }


    }
}
