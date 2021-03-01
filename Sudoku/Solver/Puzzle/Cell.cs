using System;
using System.Collections.Generic;

namespace Solver.Puzzle
{
    public class Cell
    {
        private int _cellValue;
        public bool IsUserCell { get; }
        private readonly Dictionary<int, bool> _map;
        public IReadOnlyDictionary<int, bool> Possibilities => _map;

        public Cell(int value, bool isUserCell)
        {
            _cellValue = value;
            IsUserCell = isUserCell;
             _map = new Dictionary<int, bool>()
             {
                 {1, false},
                 {2, false},
                 {3, false},
                 {4, false},
                 {5, false},
                 {6, false},
                 {7, false},
                 {8, false},
                 {9, false}
             };
        }
        
        public int Value
        {
            get => _cellValue;
            set
            {
                if (!IsUserCell)
                    throw new InvalidOperationException("You Can't Change value on board cells");
                _cellValue = value;
            }
        }

        public void SetPossibility(int key)
        {
            if (!IsUserCell)
                throw new InvalidOperationException("You Can't Change value on board cells");
            _map[key] = true;
        }

        public void RemovePossibility(int key)
        {
            if (!IsUserCell)
                throw new InvalidOperationException("You Can't Change value on board cells");
            _map[key] = false;
        }
    }
}