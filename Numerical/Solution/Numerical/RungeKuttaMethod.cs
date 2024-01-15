using Mathematics.Utils;

namespace Numerical.Solution.Numerical
{
    public class RungeKuttaMethod : INumericalMethod<double>
    {
        public double GetNextY(FunctionXY<double> equation, double x, double y, double step)
        {
            double k1i = equation(x, y);
            double k2i = equation(x + step / 2, y + step / 2 * k1i);
            double k3i = equation(x + step / 2, y + step / 2 * k2i);
            double k4i = equation(x + step, y + step * k3i);
            return y + step / 6 * (k1i + 2 * k2i + 2 * k3i + k4i);
        }
    }
}
