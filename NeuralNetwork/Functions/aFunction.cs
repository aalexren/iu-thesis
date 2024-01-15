using static System.Math;

namespace NeuralNetwork.Functions
{
    /// <summary>
    /// x_hat(t; x_0, theta) = x_0 + a(t) * N(t; x_0, theta; w);
    /// </summary>
    public class aFunction
    {
        public enum FunctionType
        {
            Step,
            Linear,
            Exponential,
        }

        public aFunction(FunctionType functionType)
        {
            _functionType = functionType;
        }

        public aFunction(aFunction copy)
        {
            _functionType = copy._functionType;
        }

        public double F(double x, double x0, double xN)
        {
            switch (_functionType)
            {
                default:
                case FunctionType.Linear: return (x - x0) / (xN - x0);
                case FunctionType.Exponential: return 1.0 - Exp(-(x - x0) / (xN - x0));
                case FunctionType.Step: return x == x0 ? 0.0 : 1.0;
            }
        }

        public double DFDX(double x, double x0, double xN)
        {
            switch (_functionType)
            {
                default:
                case FunctionType.Linear: return 1.0 / (xN - x0);
                case FunctionType.Exponential: return Exp(-(x - x0) / (xN - x0)) / (xN - x0);
                case FunctionType.Step: return 0.0;
            }
        }


        private FunctionType _functionType;
    }
}
