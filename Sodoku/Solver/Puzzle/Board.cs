using System;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Puzzle
{
    public class Board
    {
        private int[,] _board;

        public int[,] FullBoard
        {
            get => _board;
            set
            {
                if (value.GetLength(0) != 9 || value.GetLength(1) != 9)
                    throw new ArgumentException($"{nameof(value)} must be a 9 by 9 multidimensional array");
                if (!IsValidRow(value))
                    throw new ArgumentException($"{nameof(value)} is an invalid Puzzle due to a duplicate in rows");
                if (!IsValidColumn(value))
                    throw new ArgumentException($"{nameof(value)} is an invalid puzzle due to a duplicate in columns");
                if (!IsValidBox(value))
                    throw new ArgumentException($"{nameof(value)} is an invalid puzzle due to a duplicate in boxes");
                _board = value;
            }
        }

        private static bool IsValidRow(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var row = new HashSet<int>();
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (IsBlankBox(board[i,j]))
                        continue;
                    if (!row.Add(board[i, j]))
                        return false;
                }
            }
            return true;
        }
        private static bool IsValidColumn(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var column = new HashSet<int>();
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if (IsBlankBox(board[j,i]))
                        continue;
                    if (!column.Add(board[j, i]))
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

        private static bool IsBlankBox(int num)
        {
            return num == 0;
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