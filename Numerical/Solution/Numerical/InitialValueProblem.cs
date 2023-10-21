using Numerical.Utils;

namespace Numerical.Numerical
{
    public class InitialValueProblem
    {
        public InitialValueProblem(double value, FunctionXY<double> derivative)
        {
            _value = value;
            _derivative = derivative;
        }

        public double Value => _value;
        public FunctionXY<double> Derivative => _derivative;

        private double _value;
        private FunctionXY<double> _derivative;
    }
}
