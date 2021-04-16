using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading;

namespace AS_GameOfLife
{
    public class Program
    {
        public static void Main()
        {

            //Test();

        }

        private static void Test()
        {
            var board = new GameBoard();
            board.FillBoard(6, 6);
            PrintBoard(board.Board);
            board.NextGeneration();
            PrintBoard(board.Board);
        }
        private static void PrintBoard(List<List<Cell>> board)
        {
            Console.WriteLine();
            Console.WriteLine("---Board---");

            for (int posY = 0; posY < board.Count; posY++)
            {
                for (int posX = 0; posX < board[posY].Count; posX++)
                {
                    var cell = board[posY][posX];
                    string txt = "0";
                    if (cell.IsAlive())
                    {
                        txt = "1";
                    }
                    
                    Console.Write(txt + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}