namespace Game;
public class TicTacToe
    {
        private static bool[,] _taken =
        {
            {false, false, false},
            {false, false, false},
            {false, false, false}
        };
        private static string[,] _grid = 
        { 
            {"[ ]","[ ]","[ ]", "1"}, 
            {"[ ]","[ ]","[ ]", "2"},
            {"[ ]","[ ]","[ ]", "3"},
            {" A ", " B ", " C ",""} 
        };
        
        public static string[,] GameGrid 
        { 
            get { return _grid; } 
            set { GameGrid = value; } 
        }
        public static void PrintBoard()
        {
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
            if(_taken[y,x])
            Console.WriteLine("That spot is already taken");
            else
            {
                _taken[y,x] = true;
                string Circle = GameGrid[y,x].Replace(" ", "O");
                GameGrid[y,x] = Circle; 
            }
        }
        public static void CheckInput(ref string in_x, ref string in_y, ref int x, ref int y)
        {
            switch(in_x)
                {
                    case "A":
                    x = 0;
                    break;
                    case "B":
                    x = 1;
                    break;
                    case "C":
                    x = 2;
                    break;
                }
                switch(in_y)
                {
                    case "1":
                    y = 0;
                    break;
                    case "2":
                    y = 1;
                    break;
                    case "3":
                    y = 2;
                    break;
                }
        }
    }
