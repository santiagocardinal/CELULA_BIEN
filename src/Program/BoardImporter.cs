using System.IO;
using System.Linq;

namespace Ucu.Poo.GameOfLife
{
    public class BoardImporter
    {
        //VER TEMA RUTA RELATIVA Y/O HIBRIDA
        static string url = @"C:\Users\Lucia\programacion2\jueguito\assets\board.txt";
        static string content = File.ReadAllText(url);
        static string[] contentLines = content.Split('\n').Select(l => l.Trim('\r')).ToArray();
        private Cell[,] board;

        public BoardImporter()
        {
            board = new Cell[contentLines.Length, contentLines[0].Length];
        }
        
        public Cell [,] Import()
        {
            
            for (int  y=0; y<contentLines.Length;y++)
            {
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        board[x,y]=new Cell(true);
                    }
                    else
                    {
                        board[x,y]=new Cell(false);
                    }
                }
            }
            return board;
        }
    }
}