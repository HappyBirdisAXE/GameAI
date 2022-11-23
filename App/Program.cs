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
            string CPInput = "";
            string Option = "";

            int X = 0;
            int Y = 0;

            bool Play = true;
            bool TryAgain = false;

            while(Play)
                {
                    while(!TicTacToe.PlayerWinState && !TicTacToe.ComputerWinState)
                    {
                        X = 0;
                        Y = 0;
                        TicTacToe.PrintBoard();

                        if(TicTacToe.Turn == "PLAYER")
                        {
                            Input = Console.ReadLine();

                            TicTacToe.CheckInput(ref Input,ref X,ref Y);
                        }
                        else
                        {
                            CPInput = "";
                            CPInput += 
                            (Bot.Choice.FixedLetters("A", "B", "C") + Convert.ToString(Bot.Choice.FixedNumber(1,3)));
                            TicTacToe.CheckInput(ref CPInput,ref X,ref Y);
                            if(TicTacToe.PlayerTaken[X,Y] || TicTacToe.ComputerTaken[X,Y])
                            {
                                TryAgain = true;
                                while(TryAgain)
                                {
                                    CPInput = "";
                                    CPInput += 
                                    (Bot.Choice.FixedLetters("A", "B", "C") + Convert.ToString(Bot.Choice.FixedNumber(1,3)));
                                    TicTacToe.CheckInput(ref CPInput,ref X,ref Y);
                                    if(TicTacToe.PlayerTaken[X,Y] ||  TicTacToe.ComputerTaken[X,Y]) TryAgain = false;
                                }
                            }
                        }
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
                        { TicTacToe.ResetGame(); break; }
                    }
            }
        }
    }
}
