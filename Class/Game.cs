using System.Linq;
namespace Game;
public class TicTacToe
    {
        private static string _turn = "PLAYER"; 
        //_turn should be == "PLAYER" when it's player's turn then
        // "COMPUTER" when it's the computer's turn;
        private static bool[,] _computer_taken =
        {
            {false, false, false},
            {false, false, false},
            {false, false, false}
        };
        private static bool[,] _player_taken =
        {
            {false, false, false},
            {false, false, false},
            {false, false, false}
        };
        private static bool _player_win_state = false;
        private static bool _computer_win_state = false;  
        private static string[,] _grid = 
        { 
            {"[ ]","[ ]","[ ]", "1"}, 
            {"[ ]","[ ]","[ ]", "2"},
            {"[ ]","[ ]","[ ]", "3"},
            {" A ", " B ", " C ",""} 
        };
        
        public static string[,] GameGrid = _grid;
        public static bool PlayerWinState { get => _player_win_state; }
        public static bool ComputerWinState { get => _computer_win_state; }
        public static string Turn { get => _turn; } 

        public static void PrintBoard()
        {
            //Simple, prints the board with or without any changes
            int RowSize = GameGrid.GetLength(0);
            int ColumnSize = GameGrid.GetLength(1);
            for(int i = 0; i < RowSize; i++)
            {
                for(int j = 0; j < ColumnSize; j++)
                Console.Write(GameGrid[i,j]);
                Console.WriteLine();
            }
        }
        public static void ChangeGrid(int y, int x)
        {
            //Changes the grid to mark the Player's/Computer's changes
            if(_player_taken[y,x] || _computer_taken[y,x])
            Console.WriteLine("That spot is already taken");
            else if(_turn == "PLAYER")
            {
                _player_taken[y,x] = true;
                string Circle = GameGrid[y,x].Replace(" ", "O");
                GameGrid[y,x] = Circle; 
            }
            else if(_turn == "COMPUTER")
            {
                _computer_taken[y,x] = true;
                string XMark = GameGrid[y,x].Replace(" ", "X");
                GameGrid[y,x] = XMark; 
            }
        }
        public static void CheckInput(ref string input, ref int x, ref int y)
        {
            bool Valid = false;
            string Character1 = input.Substring(0,1);
            string Character2 = input.Substring(1,1);
            //Checks if the coordinates are valid
            if
            (
                (!input.ToUpper().Contains('A') && !input.ToUpper().Contains('B') && !input.ToUpper().Contains('C')) ||
                (!input.ToUpper().Contains('1') && !input.ToUpper().Contains('2') && !input.ToUpper().Contains('3'))
            )
                {Console.WriteLine("Your input in invalid");
                Console.ReadLine();}
            else Valid = true;

            //Checks coordinates.
            if(Valid)
            {
                if(Character1.ToUpper().Contains('A')) { x = 0; }
                else if(Character1.ToUpper().Contains('B')) { x = 1; }
                else if(Character1.ToUpper().Contains('C')) { x = 2; }

                if(Character2.Contains('1')) { y = 0; }
                else if(Character2.Contains('2')){ y = 1; }
                else if(Character2.Contains('3')){ y = 2; }
            }
        }
        public static void ChangeUserTurn()
        {
            //Changes the turn for the marker to be different character
            if(_turn == "PLAYER") _turn = "COMPUTER";
            else if (_turn == "COMPUTER") _turn = "PLAYER";
        }
        public static void CheckWinState()
        {
            //Checks the grid to see if there is markers that are in a row
            if
            (
                (_player_taken[0,0] && _player_taken[0,1] && _player_taken[0,2])||
                (_player_taken[1,0] && _player_taken[1,1] && _player_taken[1,2])||
                (_player_taken[2,0] && _player_taken[2,1] && _player_taken[2,2])||
                (_player_taken[0,0] && _player_taken[1,0] && _player_taken[2,0])||
                (_player_taken[0,1] && _player_taken[1,1] && _player_taken[2,1])||
                (_player_taken[0,2] && _player_taken[1,2] && _player_taken[2,2])||
                (_player_taken[0,0] && _player_taken[1,1] && _player_taken[2,2])||
                (_player_taken[0,2] && _player_taken[1,1] && _player_taken[2,0]) 
            ) _player_win_state = true;

            else if
            (
                (_computer_taken[0,0] && _computer_taken[0,1] && _computer_taken[0,2])||
                (_computer_taken[1,0] && _computer_taken[1,1] && _computer_taken[1,2])||
                (_computer_taken[2,0] && _computer_taken[2,1] && _computer_taken[2,2])||
                (_computer_taken[0,0] && _computer_taken[1,0] && _computer_taken[2,0])||
                (_computer_taken[0,1] && _computer_taken[1,1] && _computer_taken[2,1])||
                (_computer_taken[0,2] && _computer_taken[1,2] && _computer_taken[2,2])||
                (_computer_taken[0,0] && _computer_taken[1,1] && _computer_taken[2,2])||
                (_computer_taken[0,2] && _computer_taken[1,1] && _computer_taken[2,0])
            ) _computer_win_state = true;
        }
        public static void ResetGame()
        {
            GameGrid = _grid;
            _player_win_state = false;
            _computer_win_state = false;
            _turn = "PLAYER";
        }
    }
