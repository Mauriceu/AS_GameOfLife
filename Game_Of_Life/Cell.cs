using System.Collections.Generic;

namespace AS_GameOfLife
{
    public class Cell
    {

        private const int OVERPOPULATION_MINIMUM = 4;
        private const int SOLITUDE_MAXIMUM = 1;
        private const int BIRTH_MINIMUM = 2;
        private const int BIRTH_MAXIMUM = 3;

        private List<Cell> _neighbours;
        private bool _cellLivesAfterGenerationChange;
        private bool _cellIsDead;

        public void Main()
        {
            _neighbours = new List<Cell>();
            _cellIsDead = true;
        }

        public void AddNeighbour(Cell cell)
        {
            _neighbours.Add(cell);   
        }

        public bool IsDead()
        {
            return _cellIsDead;
        }

        public void EvolveCell()
        {
            if (_cellLivesAfterGenerationChange)
            {
                _cellIsDead = false;
            }
            else
            {
                _cellIsDead = true;
            }
        }


        public void CheckIfCellLivesAfterGenerationChange()
        {
            int livingNeighbours = 0;

            foreach (var cell in _neighbours)
            {
                if (!cell._cellIsDead)
                {
                    livingNeighbours++;
                }

                // Zelle stirbt an Überpopulation
                if (!_cellIsDead && livingNeighbours >= OVERPOPULATION_MINIMUM)
                {
                    _cellLivesAfterGenerationChange = false;
                }
            }

            // Zelle stirbt an Einsamkeit
            if (!_cellIsDead && livingNeighbours <= SOLITUDE_MAXIMUM)
            {
                _cellLivesAfterGenerationChange = false;
            }

            // Zelle wird geboren (falls Tod)
            if (_cellIsDead && livingNeighbours is >= BIRTH_MINIMUM and <= BIRTH_MAXIMUM)
            {
                _cellLivesAfterGenerationChange = true;
            }
        }
    }
}