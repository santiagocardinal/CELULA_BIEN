namespace Ucu.Poo.GameOfLife
{
public class Board
    {
        private Cell[,] cells;

        public int Width { get { return cells.GetLength(0); } }
        public int Height { get { return cells.GetLength(1); } }
        
        public Board(Cell[,] matriz)
        {
            this.cells = matriz;
        }

        public Board(int width, int height)
        {
            this.cells = new Cell[width,height];
            for (int i = 0; i < width ; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.cells[i, j] = new Cell(false);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[x, y];
        }
    }
}
