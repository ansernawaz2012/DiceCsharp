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
        Score score = new Score(); 

        //Constructor starts game
        public Game()
        {
            StartGame();
        }


        // creates new instance of a player and starts loop
        public void StartGame()
        {

            Console.WriteLine($"{playerOne.Name} press the return key to roll the dice.");

            Console.ReadKey();

            
            // Loop until score >= 20 or a 1 is rolled
            while (!gameEnded)
            {

                int currentRoll = Dice.Roll();

                Console.WriteLine($"You have rolled a {currentRoll}");


                playerOne = score.CheckDiceScore(playerOne, currentRoll);

                //playerOne.Score += currentRoll;


                //if (currentRoll == 1)
                //{
                //    gameEnded = true;
                //    Console.WriteLine($"Game Over! Your score is {playerOne.Score}");
                //    Console.WriteLine("Press r to Restart or q to Quit");

                // userInstruction = Console.ReadLine();

                // CheckUserInput(userInstruction);

                //}
                //else if(playerOne.Score >= 20)
                //{
                //    gameEnded = true;
                //    Console.WriteLine($"You have won!!!! Your score is {playerOne.Score}");
                //    Console.ReadLine();

                //}
                //else
                //{
                //    Console.WriteLine($"Your current score is {playerOne.Score}");
                //    Console.WriteLine("Press the return key to roll again.");

                //    Console.ReadLine();

                //}

                if (playerOne.GameLost)
                {
                    gameEnded = true;
                    Console.WriteLine($"Game Over! Your score is {playerOne.Score}");
                    Console.WriteLine("Press r to Restart or q to Quit");
                    userInstruction = Console.ReadLine();

                     CheckUserInput(userInstruction);
                }
                else if (playerOne.GameWon)
                {
                    gameEnded = true;
                        Console.WriteLine($"You have won!!!! Your score is {playerOne.Score}");
                        Console.ReadLine();

                        Console.WriteLine("Press r to Restart or q to Quit");
                        userInstruction = Console.ReadLine();

                        CheckUserInput(userInstruction);
                }

                else
                {
                    Console.WriteLine($"Your current score is {playerOne.Score}");
                        Console.WriteLine("Press the return key to roll again.");

                        Console.ReadLine();
                }

            }


        }

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

        //private void EndGame()
        //{
        //    return;

        //}

        private void RestartGame()
        {
            playerOne.Score = 0;
            playerOne.GameWon = false;
            playerOne.GameLost = false;
            gameEnded = false;
            StartGame();
        }
    }
}
