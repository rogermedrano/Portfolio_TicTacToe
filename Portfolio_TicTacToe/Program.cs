using BoardLogic;
using System;

namespace Portfolio_TicTacToe
{
    class Program
    {
        static Board game = new Board();
        //static int[] gameBoard = new int[9];
        static void Main(string[] args)
        {
            int userTurn = -1;
            int opponentTurn = -1;
            Random rand = new Random();

            while (game.checkForWinner() ==0)
            {
                // don't overwrite a square
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Enter a number 0-8");
                    userTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You entered " + userTurn);
                }

                game.Grid[userTurn] = 1;

                if (game.isBoardFull())                
                    break;
               

                //don't let computer pick an invalid square
                while (opponentTurn == -1 || game.Grid[opponentTurn] != 0)
                {
                    opponentTurn = rand.Next(9);
                    Console.WriteLine("Your opponent chooses " + opponentTurn);
                }

                game.Grid[opponentTurn] = 2;

                if (game.isBoardFull())
                //{
                    break;
                //}

                printBoard();   
            }
            Console.WriteLine("Player " + game.checkForWinner() + " won the game!");
        }


        private static void printBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                //print the gameboard
                //Console.WriteLine("Square " +i+ " contains " + gameBoard[i]);

                //print X or O for each square
                //0 = empty;  1 = Player1 (X); 2 = Player2 (O)

                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("O");
                }

                //create makeshift grid
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
