using System.ComponentModel;

namespace Ucu.Poo.GameOfLife
{
    public class Rules
    {
        // Calcula la siguiente generación del juego
        public static Board NextGeneration(Board gameBoard)
        {
            int boardWidth = gameBoard.Width;
            int boardHeight = gameBoard.Height;
            // Inicializar todas las posiciones del cloneboard con una celda muerta
            Board cloneboard = new Board(boardWidth, boardHeight);
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard.GetCell(i,j).Alive)
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(gameBoard.GetCell(x,y).Alive)
                    {
                        aliveNeighbors--;
                    }
                    if (gameBoard.GetCell(x,y).Alive && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard.GetCell(x,y).Alive = false;
                    }
                    else if (gameBoard.GetCell(x,y).Alive && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard.GetCell(x,y).Alive = false;
                    }
                    else if (!gameBoard.GetCell(x,y).Alive && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard.GetCell(x,y).Alive = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard.GetCell(x,y).Alive = gameBoard.GetCell(x,y).Alive;
                    }
                }
            }
            return cloneboard;
        }

    }
}
