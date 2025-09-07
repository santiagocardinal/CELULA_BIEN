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
        public void NextGeneration()
        {
            // Inicializar todas las posiciones del cloneboard con una celda muerta
            Cell[,] cloneboard = new Cell[boardHeight, boardWidth];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    cloneboard[x, y] = new Cell(false);
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j].Alive)
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(gameBoard[x,y].Alive)
                    {
                        aliveNeighbors--;
                    }
                    if (gameBoard[x,y].Alive && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y].Alive = false;
                    }
                    else if (gameBoard[x,y].Alive && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y].Alive = false;
                    }
                    else if (!gameBoard[x,y].Alive && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y].Alive = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = gameBoard[x,y];
                    }
                }
            }
            gameBoard = cloneboard;
        }

        
        // Permite acceder al tablero actual
        public Cell[,] GetBoard()
        {
            return gameBoard;
        }
    }
}
