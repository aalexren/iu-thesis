using Core;
using Mathematics.Statistics;
using Mathematics.Utils;

namespace NeuralNetwork
{
    public abstract class SingleLayered : IFunctionX<double>
    {
        public SingleLayered(int numberOfParams, Distribution.DistributionType distribution, ActivationFunction.ActivationFunctionType activationFunction) 
        {
            _numberOfParams = numberOfParams;
            _distributionType = distribution;
            _activationFunction = activationFunction;
            _params = (new Vector(3 * numberOfParams + 1, -5.0, -5.0)).Vectorize(new Distribution(distribution));  // FIXME hardcoded params?
            _N = new SingleLayeredFunctionX(new ActivationFunction(activationFunction), numberOfParams);
        }

        public abstract double Apply(double x);
        public abstract double Loss(Vector trainingPoints, Vector parameters, double eps); // FXIME difference s
                                                                                           // chema

        protected int _numberOfParams;
        protected Vector _params;
        protected SingleLayeredFunctionX _N;
        protected Distribution.DistributionType _distributionType;
        protected ActivationFunction.ActivationFunctionType _activationFunction;
    }
}
