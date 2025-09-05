using System.Collections.Generic;

namespace Ucu.Poo.GameOfLife;

public class Board
{
    private Cell[,] cells;

    public Cell[,] Cells
    {
        get { return cells; }
        set { cells = value;
        }
    }

    public Board(Cell [,] matriz)
    {
        this.Cells = matriz;
    }
}
