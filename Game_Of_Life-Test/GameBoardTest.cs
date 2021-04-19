using System;
using Game_Of_Life;
using NUnit.Framework;

namespace Game_Of_Live_Test
{
    public class Tests
    {
        private GameBoard Board;
        
        [SetUp]
        public void Setup()
        {
            Board = new GameBoard(4, 4);
            Board.FillBoard();
        }

        [Test]
        public void GenerationChange_Test()
        {
            Board.Board[0][0].SetStatus(true); // Should die of solitude
            Board.Board[0][2].SetStatus(true);
            Board.Board[1][2].SetStatus(true); // Should die of overpopulation
            Board.Board[1][3].SetStatus(true);
            Board.Board[2][1].SetStatus(true);
            Board.Board[2][2].SetStatus(true);
            Board.NextGeneration();

            // First Row
            Assert.IsFalse(Board.Board[0][0].IsAlive());
            Assert.IsTrue(Board.Board[0][1].IsAlive());
            Assert.IsTrue(Board.Board[0][2].IsAlive());
            Assert.IsTrue(Board.Board[0][3].IsAlive());
            // Second Row
            Assert.IsFalse(Board.Board[1][0].IsAlive());
            Assert.IsFalse(Board.Board[1][1].IsAlive());
            Assert.IsFalse(Board.Board[1][2].IsAlive());
            Assert.IsTrue(Board.Board[1][3].IsAlive());
            // Third Row
            Assert.IsFalse(Board.Board[2][0].IsAlive());
            Assert.IsTrue(Board.Board[2][1].IsAlive());
            Assert.IsTrue(Board.Board[2][2].IsAlive());
            Assert.IsTrue(Board.Board[2][3].IsAlive());
        }

        [Test]
        public void Neighbours_Test()
        {
            int currentRow = 1;
            foreach (var row in Board.Board)
            {
                int currentCell = 1;
                foreach (var cell in row)
                {
                    var amountNeighbours = cell.Neighbours.Count;
                    
                    // First and Last Row
                    if (currentRow == 1 || currentRow == Board.Height)
                    {
                        // First and Last Cell of row
                        if (currentCell == 1 || currentCell == Board.Width)
                        {
                            Assert.AreEqual(3, amountNeighbours);
                        }
                        // Middle-Cells
                        if (currentCell > 1 && currentCell < Board.Width)
                        {
                            Assert.AreEqual(5, amountNeighbours);
                        }
                    }
                    // Middle-Rows
                    if (currentRow > 1 && currentRow < Board.Height)
                    {
                        // First and Last Cell of row
                        if (currentCell == 1 || currentCell == Board.Width)
                        {
                            Assert.AreEqual(5, amountNeighbours);
                        }
                        // Middle-Cells
                        if (currentCell > 1 && currentCell < Board.Width)
                        {
                            Assert.AreEqual(8, amountNeighbours);
                        }
                    }
                    currentCell++;
                }
                currentRow++;
            }
        }
    }
}