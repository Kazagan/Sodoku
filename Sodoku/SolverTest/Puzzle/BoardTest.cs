using System;
using Xunit;
using Solver.Puzzle;

namespace SolverTest.Puzzle
{
    public class BoardTests
    {
        private readonly int[,] _input = Setup();

        private static int[,] Setup()
        {
            return new int[9,9]
            {
                {4, 0, 0, 9, 1, 3, 0, 6, 0},
                {9, 0, 0, 0, 8, 0, 0, 4, 2},
                {0, 0, 0, 0, 0, 0, 1, 9, 7},
                {0, 0, 0, 4, 0, 0, 6, 8, 0},
                {0, 0, 0, 0, 0, 2, 0, 3, 0},
                {7, 0, 4, 5, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 5, 0, 2, 0},
                {3, 4, 0, 0, 0, 6, 0, 5, 0},
                {2, 0, 0, 0, 0, 0, 4, 0, 3}
            };
        }
        
        [Fact]
        public void IsBoard()
        {  
            var board = new Board {FullBoard = _input};
            Assert.NotEmpty(board.FullBoard);
        }

        [Fact]
        public void IsNotBoardRows()
        {
            var brd = CopyArray(_input, 8, 9);
            Assert.Throws<ArgumentException>(() => new Board() {FullBoard = brd});
        }

        [Fact]
        public void IsNotBoardColumns()
        {
            var brd = CopyArray(_input, 9, 8);
            Assert.Throws<ArgumentException>(() => new Board() {FullBoard = brd});
        }

        [Fact]
        public void HasInvalidRow()
        {
            var brd = _input;
            brd[0, 1] = brd[0, 0];
            Assert.Throws<ArgumentException>(() => new Board() {FullBoard = brd});
        }
        
        [Fact]
        public void HasInvalidColumn()
        {
            var brd = _input;
            brd[0, 0] = brd[5, 0];
            Assert.Throws<ArgumentException>(() => new Board() {FullBoard = brd});
        }

        [Fact]
        public void HasInvalidBox()
        {
            var brd = _input;
            brd[4,1] = 7;
            Assert.Throws<ArgumentException > (() => new Board() {FullBoard = brd});
        }
        
        private static int[,] CopyArray(int[,] original, int rows, int columns)
        {
            var output = new int[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    output[i, j] = original[i, j];
                }
            }
            return output;
        }
    }
}