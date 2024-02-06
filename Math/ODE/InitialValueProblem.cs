using Mathematics.Utils;

namespace Mathematics.ODE
{
    public class InitialValueProblem
    {

        public InitialValueProblem(double y0, FunctionXY<double> derivative, double x0, double xN)
        {
            _y0 = y0;
            _derivative = derivative;
            _x0 = x0;
            _xN = xN;
        }

        public double y0 => _y0;
        public double x0 => _x0;
        public double xN => _xN;
        public FunctionXY<double> Derivative => _derivative;

        private double _y0;
        private FunctionXY<double> _derivative;
        private double _x0;
        private double _xN;
    }
}
