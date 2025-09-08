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
            
            // Creamos el printer
            BoardPrinter printer = new BoardPrinter(board);

            // Bucle infinito para mostrar iteraciones
            while (true)
            {   Console.Clear();
                //Console.SetCursorPosition(0,0);
                printer.PrintBoard();     // Imprime el tablero
                board = Rules.NextGeneration(board);   // Calcula la siguiente generación
                
                // Actualizamos el tablero y el printer
                
                printer = new BoardPrinter(board);

                //Thread.Sleep(300);        // Pausa de medio segundo entre generaciones
            }
        }
    }
}