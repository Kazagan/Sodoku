using System;
using System.Collections.Generic;

namespace Solver.Puzzle
{
    public class SudokuBoard
    {
        public Cell[,] Board { get; }
        private readonly int _rows;
        private readonly int _columns;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Row and Cell Count</param>
        /// <param name="board">int[size,size] to populate cells</param>
        /// <exception cref="ArgumentException"></exception>
        public SudokuBoard(int size, int[,] board)
        {
            _rows = size;
            _columns = size;
            if (board.GetLength(0) != _rows || board.GetLength(1) != _columns)
                throw new ArgumentException($"{nameof(board)} needs to be a Square array");
            Board = PopulateCells(board);
            
            
            
            if (!IsValidRow(Board))
                throw new ArgumentException($"{nameof(board)} is an invalid Puzzle due to a duplicate in rows");
            if (!IsValidColumn(Board))
                throw new ArgumentException($"{nameof(board)} is an invalid puzzle due to a duplicate in columns");
            if (!IsValidBox(board))
                throw new ArgumentException($"{nameof(board)} is an invalid puzzle due to a duplicate in boxes");
        }

        private static bool IsBlankBox(int num) => num == 0;

        private Cell[,] PopulateCells(int[,] values)
        {
            var cells = new Cell[_rows, _columns];
            for (var row = 0; row < _rows; row++)
            {
                for (var column = 0; column < _columns; column++)
                {
                    var cellValue = values[row, column];
                    cells[row, column] = new Cell(cellValue, IsBlankBox(cellValue));
                }
            }
            return cells;
        }

        private static bool IsValidRow(Cell[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var row = new HashSet<int>();
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (IsBlankBox(board[i,j].Value))
                        continue;
                    if (!row.Add(board[i, j].Value))
                        return false;
                }
            }
            return true;
        }
        private static bool IsValidColumn(Cell[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var column = new HashSet<int>();
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (IsBlankBox(board[j,i].Value))
                        continue;
                    if (!column.Add(board[j, i].Value))
                        return false;
                }
            }
            return true;
        }

        private static bool IsValidBox(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i += 3)
            {
                for (var j = 0; j < board.GetLength(1); j += 3)
                {
                    if (!CheckBox(i, j, board))
                        return false;
                }
            }

            return true;
        }

        private static bool CheckBox(int row, int column, int[,] board)
        {
            var box = new HashSet<int>();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Console.WriteLine(board[row + i, column + j]);
                    if (IsBlankBox(board[row + i, column + j]))
                        continue;
                    if (!box.Add(board[row + i, column + j]))
                        return false;
                }
            }
            return true;
        }
    }
}

//   0   4 0 0 9 1 3 0 6 0
//   1   9 0 0 0 8 0 0 4 2
//   2   0 0 0 0 0 0 1 9 7
//   3   0 0 0 4 0 0 6 8 0
//   4   0 0 0 0 0 2 0 3 0
//   5   7 0 4 5 0 0 0 0 0
//   6   0 0 1 0 0 5 0 2 0
//   7   3 4 0 0 0 6 0 5 0
//   8   2 0 0 0 0 0 4 0 3