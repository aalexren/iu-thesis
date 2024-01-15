using Mathematics.Utils;

namespace Numerical.Solution.Numerical
{
    public class ImprovedEulerMethod : INumericalMethod<double>
    {
        public double GetNextY(FunctionXY<double> equation, double x, double y, double step)
        {
            double k1i = equation(x, y);
            double k2i = equation(x + step, y + step * k1i);
            return y + step / 2 * (k1i + k2i);
        }
    }
}
