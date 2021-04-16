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
            board.FillBoard(5, 5);
            RandomizeBoardValues(board.Board);
            board.PrintBoard();
            //board.NextGeneration();
            //board.PrintBoard();
            board.NextGenerationOnTimer();
            Console.ReadLine();
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
    }
}