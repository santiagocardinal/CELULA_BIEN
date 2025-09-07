using System;
//using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Importamos el tablero inicial desde el archivo
            BoardImporter importer = new BoardImporter();
            Cell[,] initialCells = importer.Import();

            // Creamos el objeto Board
            Board board = new Board(initialCells);

            // Creamos las reglas con el tablero inicial
            Rules rules = new Rules(board.Cells);

            // Creamos el printer
            BoardPrinter printer = new BoardPrinter(board.Cells);

            // Bucle infinito para mostrar iteraciones
            while (true)
            {
                //Console.SetCursorPosition(0,0);
                printer.PrintBoard();     // Imprime el tablero
                rules.NextGeneration();   // Calcula la siguiente generación

                // Actualizamos el tablero y el printer
                board.Cells = rules.GetBoard();
                printer = new BoardPrinter(board.Cells);

                //Thread.Sleep(300);        // Pausa de medio segundo entre generaciones
            }
        }
    }
}