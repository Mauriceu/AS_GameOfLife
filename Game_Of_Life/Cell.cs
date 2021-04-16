using System;
using System.Collections.Generic;

namespace Game_Of_Life
{
    public class Cell
    {

        private const int OVERPOPULATION_MINIMUM = 4;
        private const int SOLITUDE_MAXIMUM = 1;
        private const int BIRTH_MINIMUM = 2;
        private const int BIRTH_MAXIMUM = 3;

        private readonly string _id;
        private readonly List<Cell> _neighbours;
        private bool _cellLivesAfterGenerationChange;
        private bool _cellIsAlive;

        public Cell(string id)
        {
            _id = id;
            _neighbours = new List<Cell>();
            _cellIsAlive = false;
            _cellLivesAfterGenerationChange = _cellIsAlive;
        }

        public string ID => _id;

        public void AddNeighbour(Cell neighbour)
        {
            _neighbours.Add(neighbour);
        }
        public bool HasNeighbour(Cell cell)
        {
            return _neighbours.Contains(cell);
        }

        /**
         * For Testing
         */
        public void SetStatus(bool value)
        {
            _cellIsAlive = value;
            _cellLivesAfterGenerationChange = value;
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

            foreach (var cell in _neighbours)
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
            if (!IsAlive() && livingNeighbours is >= BIRTH_MINIMUM and <= BIRTH_MAXIMUM)
            {
                _cellLivesAfterGenerationChange = true;
            }
        }
    }
}