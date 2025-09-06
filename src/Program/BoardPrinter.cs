using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class BoardPrinter
    {
        private Cell[,] board; //variable que representa el tablero
        private int width; //variabe que representa el ancho del tablero
        private int height;  //variabe que representa altura del tablero
        
        public BoardPrinter(Cell[,] board)
        {
            this.board = board;
            this.height = board.GetLength(1); // filas
            this.width = board.GetLength(0);  // columnas
        }
        

        public void PrintBoard()
        {
            Console.SetCursorPosition(0, 0);
            //
            StringBuilder s = new StringBuilder();
            for (int y = 0; y<height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y].Alive)
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
            Thread.Sleep(1000); 
        }

        //=================================================
        //Invocar método para calcular siguiente generación
        //=================================================

    }
}