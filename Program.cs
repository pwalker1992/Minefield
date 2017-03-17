using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
/**
         _______GOAL_______
          4 |_|_|_|_|_|   Mines can    
          3 |_|_|_|_|_|   be in any of  
          2 |_|_|_|_|_|   these 3 rows 
          1 |_|_|x|_|_|
             a b c d e               
             
     x = Player starting position / reset position           
**/

    class Program
    {
        public static Boolean gameEnded = false;
        static Player player = new Player();
        static Mines mine1 = new Mines();
        static Mines mine2 = new Mines();
        static Mines mine3 = new Mines();
        static Lives lives = new Lives();
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            startNewGame();
        }

        static void startNewGame()
        {
            getNewMines();
            while (gameEnded != true) //Loop run until gameEnded condition is met (either run out of lives or
                                      //player has reached the goal)
            {
                displayCurrentStatus();
                takeInput();
                checkIfHitMine();
                checkIfReachedFinish();
            }
            Console.ReadLine(); //To pause the console once the game has finished
        }

        static void takeInput()
        {
            string move = Console.ReadLine();

            if (move == "up")   //If the player types up or down, then change the Y pos of the Player
            {
                player.SetPosY(player.GetPosY() + 1);
                player.SetMoves(player.GetMoves() + 1);
            }
            else if (move == "down")
            {
                player.SetPosY(player.GetPosY() - 1);
                player.SetMoves(player.GetMoves() + 1);
            }
            else if (move == "left")   //If the player types left or right, then change the X pos of the Player
            {
                player.SetPosX(player.GetPosX() - 1);
                player.SetMoves(player.GetMoves() + 1);
            }
            else if (move == "right")
            {
                player.SetPosX(player.GetPosX() + 1);
                player.SetMoves(player.GetMoves() + 1);
            }
            else if (move == "mine") //Used for debugging to check where the mines are
            {
                Console.WriteLine("Mine Positions: Mine1:" + convertNumberToAlpha(mine1.GetPosX()) +
                    "," + mine1.GetPosY() + " Mine2:" + convertNumberToAlpha(mine2.GetPosX()) +
                    "," + mine2.GetPosY() + " Mine3:" + convertNumberToAlpha(mine3.GetPosX()) +
                    "," + mine3.GetPosY());
            }
        }

        static void displayCurrentStatus()
        {
            char posX = convertNumberToAlpha(player.GetPosX());
            Console.WriteLine("Your current position is:" + posX + ","
                + player.GetPosY() + ". You have "
                + player.GetLives() + " lives left and have made "
                + player.GetMoves() + " moves. Please enter up/down/left/right.");
        }

        static void checkIfReachedFinish()  //Called after every move to check if the player has reached the goal
        {
            if (player.GetPosY() > 4)
            {
                Console.WriteLine("You reached the end! Your score (number of moves) is " + player.GetMoves());
                gameEnded = true;
            }
        }

        static void checkIfHitMine() //Called after every move to check if the player has landed on a mine
        {
            if (player.GetPosX() == mine1.GetPosX() && player.GetPosY() == mine1.GetPosY())
            {
                hitMineEffect();
            }
            else if (player.GetPosX() == mine2.GetPosX() && player.GetPosY() == mine2.GetPosY())
            {
                hitMineEffect();
            }
            else if (player.GetPosX() == mine3.GetPosX() && player.GetPosY() == mine3.GetPosY())
            {
                hitMineEffect();
            }
        }

        //Called when the player lands on the same coords as a mine
        static void hitMineEffect()
        {
            Console.WriteLine("You hit a mine. You have returned to c,0");
            player.SetPosX(2);  
            player.SetPosY(0);  //Reset player to C,0
            getNewMines();
            player.SetLives(player.GetLives() - 1);   //Take away a life
            if (player.GetLives() < 1) //If the player has run out of lives, end the game
            {
                gameEnded = true;
                Console.WriteLine("Game over. You ran out of lives.");
            }
        }

        //Called at the start of the game and every time a mine is hit
        static void getNewMines()
        {
            mine1.SetPosY(rnd.Next(1, 5));
            mine1.SetPosX(rnd.Next(0, 5));
            
            mine2.SetPosY(rnd.Next(1, 5));
            mine2.SetPosX(rnd.Next(0, 5));

            mine3.SetPosY(rnd.Next(1, 5));
            mine3.SetPosX(rnd.Next(0, 5));
        }

        //To give the chessboard effect (e.g. d,4 instead of 3,4)
        static char convertNumberToAlpha(int num)
        {
            char returnChar = 'a';
            if (num == 0)
            {
                returnChar = 'a';
            }
            else if (num == 1)
            {
                returnChar = 'b';
            }
            else if (num == 2)
            {
                returnChar = 'c';
            }
            else if (num == 3)
            {
                returnChar = 'd';
            }
            else if (num == 4)
            {
                returnChar = 'e';
            }
            return returnChar;
        }
    }
}
