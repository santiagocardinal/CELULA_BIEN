namespace Ucu.Poo.GameOfLife
{
    public class Rules
    {
        private Cell[,] gameBoard;
        private int boardWidth;
        private int boardHeight;

        public Rules(Cell[,] initialBoard)
        {
            gameBoard = initialBoard;
            boardHeight = gameBoard.GetLength(1); 
            boardWidth = gameBoard.GetLength(0);
        }

        // Calcula la siguiente generación del juego
        

        
        // Permite acceder al tablero actual
        public Cell[,] GetBoard()
        {
            return gameBoard;
        }
    }
}
