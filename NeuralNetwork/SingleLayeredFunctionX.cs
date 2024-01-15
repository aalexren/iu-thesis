using Core;

namespace NeuralNetwork
{
    public class SingleLayeredFunctionX
    {
        public SingleLayeredFunctionX(ActivationFunction activationFunction, int numberOfParams) 
        {
            _activationFunction = activationFunction;
            _numberOfParams = numberOfParams;
        }

        public double Apply(double x, Vector v)
        {
            Vector w0 = v.SubVector(0, _numberOfParams);
            Vector b0 = v.SubVector(_numberOfParams, 2 * _numberOfParams);
            Vector w1 = v.SubVector(2 * _numberOfParams, 3 * _numberOfParams);
            double b1 = v[3 * _numberOfParams];

            Vector r = (x * w0 + b0).Vectorize(_activationFunction);
            double res = _activationFunction.Apply(r * w1 + b1);
            return res;
        }

        private ActivationFunction _activationFunction;
        private int _numberOfParams;
    }

}
