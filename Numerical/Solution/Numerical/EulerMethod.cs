using Numerical.Solution.Numerical;
using Numerical.Utils;

namespace Numerical.Numerical
{
    public class EulerMethod : INumericalMethod<double>
    {
        public double GetNextY(FunctionXY<double> equation, double x, double y, double step)
        {
            return y + step * equation(x, y);
        }
    }
}
