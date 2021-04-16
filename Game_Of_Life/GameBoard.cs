using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AS_GameOfLife
{
    
    public class GameBoard
    {

        /**
         * 2D-Liste, die alle existierenden Zellen beinhaltet
         */
        public List<List<Cell>> Board;

        private int _width;
        private int _height;

        /**
         * Erstellt die 2D-Liste, anhand der Übergabeparameter wird die Größe festgelegt
         */
        public void FillBoard(int x, int y)
        {
            _width = x;
            _height = y;
            Board = new List<List<Cell>>();

            Random r = new Random();
            for (int posY = 0; posY < _height; posY++)
            {
                Board.Add(new List<Cell>());
                for (int posX = 0; posX < _width; posX++)
                {
                    var value = false;
                    int num = r.Next(1, 100);
                    if (num < 40)
                    {
                        value = true;
                    }

                    Cell cell = new Cell((posY.ToString() + posX.ToString()), value);
                    Board[posY].Add(cell);
                } 
            }
            SetNeighbourCells();
        }

        private void SetNeighbourCells()
        {
            for (int posY = 0; posY < _height; posY++)
            {
                for (int posX = 0; posX < _width; posX++)
                {
                    IterateRowHelper(posX, posY, -1);
                    IterateRowHelper(posX, posY, 0);
                    IterateRowHelper(posX, posY, 1);
                } 
            }
        }

        private void IterateRowHelper(int posX, int posY, int offsetY)
        {
            for (var offsetX = -1; offsetX <= 1; offsetX++)
            {
                Cell neighbour = null;
                try
                {
                    neighbour = Board[posY + offsetY][posX + offsetX];
                }
                catch (Exception e) {}

                if (neighbour != null &&
                    neighbour.ID != Board[posY][posX].ID)
                {
                    Board[posY][posX].AddNeighbour(neighbour);
                }
            }
        }

        /**
         * Board wird von oben links nach unten rechts iteriert. Jede Zelle durchläuft die "lebt"/"stirbt"-Logik
         * Die Veränderung einer Zelle während des Generationswechsels beeinflusst keine Nachbarzellen.
         */
        public void NextGeneration()
        {
            foreach (var row in Board)
            {
                foreach (Cell cell in row)
                {
                    cell.CheckIfCellLivesAfterGenerationChange();
                }
            }
            FinishGenerationChange();
        }

        /**
         * Da die Veränderung einer Zelle während des Generationswechsels die anderen Zellen nicht beeinflussen darf,
         * wird das Ergebnis des Wechsels zwischengespeichert und nun für jede Zelle übernommen
         */
        public void FinishGenerationChange()
        {
            foreach (var row in Board)
            {
                foreach (Cell cell in row)
                {
                    cell.EvolveCell();
                }
            }
        }
    }
}