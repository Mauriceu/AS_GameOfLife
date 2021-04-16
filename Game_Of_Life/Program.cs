using System;

namespace AS_GameOfLife
{
    public class Program
    {
        public static void Main()
        {
            var gameBoard = new GameBoard();
            gameBoard.FillBoard();
            gameBoard.NextGeneration();

                
            for (int i = 0; i <= gameBoard.Board.Count-1; i++)
            {
                var list = gameBoard.Board[i];
                Console.Write("-----------------------------------------------");
                for (int ii = 0; ii <= gameBoard.Board[i].Count-1; ii++)
                {
                    var cell = gameBoard.Board[i][i];
                    Console.Write(cell.IsDead() + ", ");
                } 
            }
        }
    }
}