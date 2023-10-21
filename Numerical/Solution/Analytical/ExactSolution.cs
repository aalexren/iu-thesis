using Numerical.Core;
using Numerical.Utils;

namespace Numerical.Solution.Analytical
{
    public class ExactSolution
    {
        public static Grid Solve(Vector x, FunctionX<double> function)
        {
            Vector y = new(new double[x.Points.Length]);
            for (int i = 0; i < x.Points.Length; i++)
            {
                y[i] = function(x[i]);
            }

            return new(Vector.DeepCopy(x), y);
        }
    }
}
