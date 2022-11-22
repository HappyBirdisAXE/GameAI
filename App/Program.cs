using System;
using AI;
using Game;
namespace App
{
    class Program
    {
        public static void Main()
        {
            string InputX = "";
            string InputY = "";
            int X = 0;
            int Y = 0;
            while(InputX != "end" && InputY != "end")
            {
                X = 0;
                Y = 0;
                TicTacToe.PrintBoard();
                
                InputX = Console.ReadLine();
                InputY = Console.ReadLine();

                InputX.ToUpper();
                InputY.ToUpper();

                TicTacToe.CheckInput(ref InputX,ref InputY,ref X,ref Y);

                Console.Clear();
                TicTacToe.ChangeGrid(Y,X);
            }
        }
    }
}