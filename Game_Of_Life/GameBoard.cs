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

        public void Main()
        {
            FillBoard();
        }
        
        /**
         * Erstellt die 2D-Liste, anhand der Übergabeparameter wird die Größe festgelegt
         */
        public void FillBoard(int x = 5, int y = 5)
        {
            Board = new List<List<Cell>>();
                
            for (int i = 0; i <= x; i++)
            {
                Board[i] = new List<Cell>();
                for (int ii = 0; ii <= y; ii++)
                {
                    Board[i][ii] = new Cell();
                } 
            }
        }

        /**
         * Board wird von oben links nach unten rechts iteriert. Jede Zelle durchläuft die "lebt"/"stirbt"-Logik
         * Die Veränderung einer Zelle während des Generationswechsels beeinflusst keine Nachbarzellen.
         */
        public void NextGeneration()
        {
            for (int i = 0; i <= Board.Count-1; i++)
            {
                List<Cell> row = Board[i];
                for (int ii = 0; ii <= row.Count-1; ii++)
                {
                    Cell cell = row[ii];
                    cell.CheckIfCellLivesAfterGenerationChange();
                } 
            }
            FinishGenerationChange();
        }

        /**
         * Da die Veränderung einer Zelle während des Generationswechsels die anderen Zellen nicht beeinflussen darf,
         * wird das Ergebnis des Wechsels in der Funktion NextGeneration() zwischengespeichert und nun für jede Zelle übernommen
         */
        public void FinishGenerationChange()
        {
            for (int i = 0; i <= Board.Count-1; i++)
            {
                List<Cell> row = Board[i];
                for (int ii = 0; ii <= row.Count-1; ii++)
                {
                    Cell cell = row[ii];
                    cell.EvolveCell();
                } 
            }
        }
    }
}