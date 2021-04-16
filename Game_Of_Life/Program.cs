using System;
using System.Collections.Generic;

namespace Game_Of_Life
{
    public class Program
    {
        public static void Main()
        {
            Test();
        }

        private static void Test()
        {
            var board = new GameBoard();
            board.FillBoard(3, 3);
            RandomizeBoardValues(board.Board);
            PrintBoard(board.Board);
            board.NextGeneration();
            PrintBoard(board.Board);
        }

        private static void RandomizeBoardValues(List<List<Cell>> board)
        {
            var r = new Random();
            foreach (var row in board)
            {
                foreach (var cell in row)
                {  
                    var value = r.Next(1, 100) < 50;
                    cell.SetStatus(value);
                }   
            }
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