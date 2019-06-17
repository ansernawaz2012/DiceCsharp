using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Game
    {
        private bool gameEnded = false;
        private string UserInstruction;
        
        //Constructor starts game
        public Game()
        {
            StartGame();
        }


        // creates new instance of a player
        public void StartGame()
        {
            Player playerOne = new Player();

            Console.WriteLine($"{playerOne.Name} press any key to roll the dice.");

            Console.ReadKey();

            

            while (!gameEnded)
            {

                int currentRoll = Dice.Roll();
                playerOne.Score += currentRoll;

                Console.WriteLine($"You have rolled a {currentRoll}");

                if (currentRoll == 1)
                {
                    gameEnded = true;
                    Console.WriteLine($"Game Over! Your score is {playerOne.Score}");
                    Console.WriteLine("Press r to Restart or q to Quit");

                 UserInstruction = Console.ReadLine();

                 CheckUserInput(UserInstruction);

                }
                else if(playerOne.Score >= 20)
                {
                    gameEnded = true;
                    Console.WriteLine($"You have won!!!! Your score is {playerOne.Score}");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine($"Your current score is {playerOne.Score}");
                    Console.WriteLine("Press any key to roll again.");

                    Console.ReadKey();

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
                EndGame();
            }
        }

        private void EndGame()
        {
            throw new NotImplementedException();
        }

        private void RestartGame()
        {
            
        }
    }
}
