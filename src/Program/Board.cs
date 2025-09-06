namespace Ucu.Poo.GameOfLife
{
public class Board
    {
        private Cell[,] cells;

        public Cell[,] Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Board(Cell[,] matriz)
        {
            this.Cells = matriz;
        }

        // Propiedades para obtener filas y columnas fácilmente
        public int Rows => cells.GetLength(0);
        public int Cols => cells.GetLength(1);
    }
}
