using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Dice
{
    public class Game
    {
        private bool gameEnded = false;
        private string userInstruction;
        Player playerOne = new Player();
       // Score score = new Score();

        //Constructor starts game
        public Game()
        {
            StartGame();
        }

        /// <summary>
        /// creates new instance of a player and starts loop
        /// </summary>
        public void StartGame()
        {

            Console.WriteLine($"{playerOne.Name} press the return key to roll the dice.");

            Console.ReadKey();


            // Loop until score >= 20 or a 1 is rolled
            while (!gameEnded)
            {

                int currentRoll = Dice.Roll();

                Console.WriteLine($"You have rolled a {currentRoll}");

                playerOne = Score.CheckDiceScore(playerOne, currentRoll);



                if (playerOne.GameLost)
                {
                    EndOfGame();
                }
                else if (playerOne.GameWon)
                {
                    EndOfGame();
                }

                else
                {
                    Console.WriteLine($"Your current score is {playerOne.Score}");
                    Console.WriteLine("Press the return key to roll again.");

                    Console.ReadLine();
                }

            }
            
        }

        /// <summary>
        /// Allow user to start a new game
        /// </summary>
        /// <param name="userInstruction"></param>
        private void CheckUserInput(string userInstruction)
        {
            if (userInstruction == "r")
            {
                RestartGame();
            }
            else if (userInstruction == "q")
            {
                return;
            }

        }
        /// <summary>
        /// reset fields when restarting game
        /// </summary>
        private void RestartGame()
        {
            playerOne.Score = 0;
            playerOne.GameWon = false;
            playerOne.GameLost = false;
            gameEnded = false;
            StartGame();
        }

        /// <summary>
        /// Check how game has ended and display message accordingly
        /// </summary>
        private void EndOfGame()
        {
            if (playerOne.GameWon)
            {
                Console.WriteLine($"You have won!!!! Your score is {playerOne.Score}");
            }
            else
            {
                Console.WriteLine($"Game Over! Your score is {playerOne.Score}");
            }
            // Set game ended flag to true to exit while loop
            gameEnded = true;

            Console.WriteLine("Press r to Restart or q to Quit");


            while (true)
            {

                userInstruction = Console.ReadLine().ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInstruction) || userInstruction !="r" && userInstruction !="q")
                    Console.WriteLine("You must enter r or q");
                else break;
            }


            CheckUserInput(userInstruction);
        }
    }
}
