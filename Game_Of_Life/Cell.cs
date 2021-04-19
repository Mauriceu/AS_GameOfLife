using System;
using System.Collections.Generic;

namespace Game_Of_Life
{
    public class Cell
    {

        private const int OVERPOPULATION_MINIMUM = 4;
        private const int SOLITUDE_MAXIMUM = 1;
        private const int BIRTH = 3;

        private bool _cellLivesAfterGenerationChange;
        private bool _cellIsAlive;

        public Cell(string id)
        {
            Id = id;
            Neighbours = new List<Cell>();
            _cellIsAlive = false;
            _cellLivesAfterGenerationChange = _cellIsAlive;
        }

        /**
         * For Testing
         */
        public void SetStatus(bool value)
        {
            _cellIsAlive = value;
            _cellLivesAfterGenerationChange = value;
        }

        public string Id { get; }

        public List<Cell> Neighbours { get; }

        public void AddNeighbour(Cell neighbour)
        {
            Neighbours.Add(neighbour);
        }
        public bool HasNeighbour(Cell cell)
        {
            return Neighbours.Contains(cell);
        }

        public bool IsAlive()
        {
            return _cellIsAlive;
        }
        public void EvolveCell()
        { 
            _cellIsAlive = _cellLivesAfterGenerationChange;
        }

        public void CheckIfCellLivesAfterGenerationChange()
        {
            int livingNeighbours = 0;

            foreach (var cell in Neighbours)
            {
                if (cell.IsAlive())
                {
                    livingNeighbours++;
                }

                // Zelle stirbt an Überpopulation
                if (IsAlive() && livingNeighbours >= OVERPOPULATION_MINIMUM)
                {
                    _cellLivesAfterGenerationChange = false;
                    return;
                }
            }

            // Zelle stirbt an Einsamkeit
            if (IsAlive() && livingNeighbours <= SOLITUDE_MAXIMUM)
            {
                _cellLivesAfterGenerationChange = false;
                return;
            }

            // Zelle wird geboren (falls Tod)
            if (!IsAlive() && livingNeighbours == BIRTH)
            {
                _cellLivesAfterGenerationChange = true;
            }
        }
    }
}