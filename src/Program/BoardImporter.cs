using System.IO;
using System.Linq;

namespace Ucu.Poo.GameOfLife
{
    public class BoardImporter
    {
        static string url = @"C:\Users\camil\P2\CELULA_BIEN\assets\board.txt";
        
        
        public Cell [,] Import()
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n').Select(l => l.Trim('\r')).ToArray();
            Cell[,] board = new Cell[contentLines.Length, contentLines[0].Length];
            
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