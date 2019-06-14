using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Game
    {
        public Game()
        {
            startGame();
        }

        public void startGame()
        {
            Player playerOne = new Player();

            Console.WriteLine(playerOne.Name);

            Console.WriteLine(Dice.Roll());


        }
    }
}
