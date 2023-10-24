using Numerical.Core;
using System;


namespace Numerical.Solution.Error
{
    internal class LocalError
    {
        public LocalError(Grid grid)
        {
            _grid = grid;
        }

        private Grid _grid;

        public Grid Grid { get { return _grid; } }
        public static LocalError ComputeLocalError(Grid exactGrid, Grid numericalGrid)
        {
            Grid difference = new(exactGrid.X, (exactGrid.Y - numericalGrid.Y).Vectorize(Math.Abs));
            return new(difference);
        }
    }
}
