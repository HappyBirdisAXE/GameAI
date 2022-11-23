using System.Linq;
using AI;
using Game;
namespace App
{
    class Program
    {
        public static void Main()
        {
            string Input = "";
            string Option = "";

            int X = 0;
            int Y = 0;

            bool Play = true;

            while(Play)
                {
                    while(!TicTacToe.PlayerWinState && !TicTacToe.ComputerWinState)
                    {
                        TicTacToe.PrintBoard();
                        Input = Console.ReadLine();

                        TicTacToe.CheckInput(ref Input,ref X,ref Y);

                        Console.Clear();
                        TicTacToe.ChangeGrid(Y,X);
                        TicTacToe.ChangeUserTurn();
                        TicTacToe.CheckWinState();
                        Console.WriteLine();
                    }

                    if(TicTacToe.PlayerWinState)
                    Console.WriteLine("Player Wins!");
                    else if(TicTacToe.ComputerWinState)
                    Console.WriteLine("Computer Wins!");

                    while(true)
                    {
                        Console.WriteLine("Continue playing? (Y/N)");
                        Option = Console.ReadLine();
                        //Checks if the player said no, which will end the program entirely
                        //else will just continue the game.
                        if(Option.ToUpper().Contains('N')) 
                        {
                            Play = false;
                            break;
                        }
                        else if(Option.ToUpper().Contains('Y')) 
                        {
                            
                            break;
                        }
                    }
            }
        }
    }
}