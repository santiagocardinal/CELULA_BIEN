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
            boardHeight = gameBoard.GetLength(0); // filas
            boardWidth = gameBoard.GetLength(1);  // columnas
        }

        // Calcula la siguiente generación del juego
        public void NextGeneration()
        {
            Cell[,] cloneboard = new Cell[boardHeight, boardWidth];

            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    int aliveNeighbors = CountAliveNeighbors(x, y);

                    if (gameBoard[y, x].Alive && (aliveNeighbors < 2 || aliveNeighbors > 3))
                    {
                        // muere por soledad o sobrepoblación
                        cloneboard[y, x] = new Cell(false);
                    }
                    else if (!gameBoard[y, x].Alive && aliveNeighbors == 3)
                    {
                        // nace por reproducción
                        cloneboard[y, x] = new Cell(true);
                    }
                    else
                    {
                        // sobrevive igual
                        cloneboard[y, x] = new Cell(gameBoard[y, x].Alive);
                    }
                }
            }

            // Actualizar tablero
            gameBoard = cloneboard;
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int count = 0;

            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    if (i == x && j == y) continue; // saltar la celda misma

                    if (j >= 0 && j < boardHeight && i >= 0 && i < boardWidth)
                    {
                        if (gameBoard[j, i].Alive)
                            count++;
                    }
                }
            }

            return count;
        }

        // Permite acceder al tablero actual
        public Cell[,] GetBoard()
        {
            return gameBoard;
        }
    }
}
