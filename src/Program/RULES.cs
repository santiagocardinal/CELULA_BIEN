namespace Ucu.Poo.GameOfLife
{
    public class RULES
    {
 
        private bool[,] gameBoard;
        private int boardWidth;
        private int boardHeight;
        private bool[,] cloneboard;
        
        public RULES(bool[,] initialBoard)
        {
            gameBoard = initialBoard;
            boardWidth = gameBoard.GetLength(0);
            boardHeight = gameBoard.GetLength(1);
            cloneboard = new bool[boardWidth, boardHeight];
            
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    
                    if (gameBoard[x, y])
                    {
                        aliveNeighbors--;
                    }
                    
                    if (gameBoard[x, y] && aliveNeighbors < 2)
                    {
                        // Regla 1: Célula viva con menos de 2 vecinos muere por baja población.
                        cloneboard[x, y] = false;
                    }
                    else if (gameBoard[x, y] && aliveNeighbors > 3)
                    {
                        // Regla 2: Célula viva con más de 3 vecinos muere por sobrepoblación.
                        cloneboard[x, y] = false;
                    }
                    else if (!gameBoard[x, y] && aliveNeighbors == 3)
                    {
                        // Regla 3: Célula muerta con exactamente 3 vecinos revive por reproducción.
                        cloneboard[x, y] = true;
                    }
                    else
                    {
                        // Regla 4: En cualquier otro caso, la célula mantiene su estado actual.
                        cloneboard[x, y] = gameBoard[x, y];
                    }
                }
            }

            // Al final, actualizamos el tablero original con la nueva generación calculada.
            gameBoard = cloneboard;
        }
    }
}
