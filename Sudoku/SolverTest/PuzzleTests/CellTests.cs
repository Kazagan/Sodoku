using System;
using System.Linq;
using Solver.Puzzle;
using Xunit;
using Xunit.Abstractions;

namespace SolverTest.PuzzleTests
{
    public class CellTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CellTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CantChangeNoneUserCell()
        {
            var cell = new Cell(0, false);
            Assert.Throws<InvalidOperationException>(() => cell.Value = 5);
        }

        [Fact]
        public void PossibilitiesDefaultToFalse()
        {
            var cell = new Cell(0, true);
            Assert.Equal(0, cell.Possibilities.Count(x => x.Value == true));
        }

        [Fact]
        public void CantSetGamePossibility()
        {
            var cell = new Cell(0, false);
            Assert.Throws<InvalidOperationException>(() => cell.SetPossibility(1));
        }

        [Fact]
        public void CanSetUserPossibility()
        {
            const int setPossibility = 1;
            var cell = new Cell(0, true);
            cell.SetPossibility(setPossibility);
            Assert.True(cell.Possibilities[setPossibility]);
        }

        [Fact]
        public void CantRemoveGamePossibility()
        {
            var cell = new Cell(0, false);
            Assert.Throws<InvalidOperationException>(() => cell.RemovePossibility(1));
        }

        [Fact]
        public void CanRemoveUserPossibility()
        {
            const int setPossibility = 2;
            var cell = new Cell(0, true);
            cell.SetPossibility(setPossibility);
            var possibility = cell.Possibilities[setPossibility];
            cell.RemovePossibility(setPossibility);
            Assert.NotEqual(possibility, cell.Possibilities[setPossibility]);
        }
    }
}