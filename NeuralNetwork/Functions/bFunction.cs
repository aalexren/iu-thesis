using static System.Math;

namespace NeuralNetwork.Functions
{
    public class bFunction
    {
        /// <summary>
        /// function to weights data points during Loss computation
        /// </summary>
        public enum FunctionType
        {
            Identity, // 1
            Exponential,
        }
        public bFunction(FunctionType functionType, double lambda = 1.0) 
        {
            _functionType = functionType;
            _lambda = lambda;
        }
        public bFunction(bFunction copy) 
        {
            _functionType = copy._functionType;
            _lambda = copy._lambda;
        }

        public double F(double x, double x0, double xN)
        {
            switch (_functionType)
            {
                default: return 1.0;
                case FunctionType.Exponential: return Exp(-_lambda * (x - x0) / (xN - x0));
            }
        }

        private FunctionType _functionType;
        private double _lambda;
    }
}
