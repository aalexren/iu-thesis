using Core;
using Mathematics.Utils;

namespace Numerical.Solution.Analytical
{
    public class ExactSolution
    {
        private Vector _X;
        private FunctionX<double> _function;

        public Vector X => _X;
        public FunctionX<double> function => _function;
        public ExactSolution(Vector X, FunctionX<double> function)
        {
            _X = X;
            _function = function;
        }
        public static Grid Solve(Vector x, FunctionX<double> function)
        {
            Vector y = new(new double[x.Points.Length]);
            for (int i = 0; i < x.Points.Length; i++)
            {
                y[i] = function(x[i]);
            }

            return new(Vector.DeepCopy(x), y);
        }

        public Grid Solve()
        {
            Vector y = new(new double[X.Points.Length]);
            for (int i = 0; i < X.Points.Length; i++)
            {
                y[i] = function(X[i]);
            }

            return new(Vector.DeepCopy(X), y);
        }
    }
}
