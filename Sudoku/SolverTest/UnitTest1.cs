using System;
using System.Diagnostics;
using Xunit;
using Solver;

namespace SolverTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Solver.First first = new Solver.First();
            Assert.Equal(true, first.IsRunning());
        }
    }
}
