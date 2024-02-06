using Core;
using Mathematics.Statistics;
using Mathematics.Utils;
using NeuralNetwork.Functions;
using Mathematics.ODE;

namespace NeuralNetwork
{
    public class SingleLayerNeuralNetwork : SingleLayeredTrained, IFunctionX<double>
    {
        public SingleLayerNeuralNetwork(InitialValueProblem ivp, aFunction aFunction_, bFunction bFunction_, int numberOfParams, Distribution.DistributionType distribution, ActivationFunction.ActivationFunctionType activationFunction) : base(numberOfParams, distribution, activationFunction)
        {
            _ivp = ivp;
            _aFunction = aFunction_;
            _bFunction = bFunction_;
        }


        public double Y(double x, Vector params_)
        {
            return _ivp.y0 + _aFunction.F(x, _ivp.x0, _ivp.xN) * _N.F(x, params_);
        }

        public double DYDX(double x, Vector params_, double eps, DifferenceSchema schema)
        {
            return _aFunction.DFDX(x, _ivp.x0, _ivp.xN) * _N.F(x, params_)
                + _aFunction.F(x, _ivp.x0, _ivp.xN) * _N.DFDX(x, params_, eps, schema);
        }

        public override double Apply(double x)
        {
            return Y(x, _params);
        }

        /// <summary>
        /// difference between computed loss and approximated analytical solns
        /// </summary>
        /// <param name="x"></param>
        /// <param name="params_"></param>
        /// <param name="eps"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        private double localDifference(double x, Vector params_, double eps, DifferenceSchema schema)
        {
            return DYDX(x, params_, eps, schema) - _ivp.Derivative(x, Y(x, params_));
        }

        public override double Loss(Vector trainingPoints, Vector parameters, double eps, DifferenceSchema schema)
        {
            double L = 0.0;
            int S = trainingPoints.Points.Length;

            for (int i = 0; i < S; i++)
            {
                double local = localDifference(trainingPoints[i], parameters, eps, schema);
                L += _bFunction.F(trainingPoints[i], _ivp.x0, _ivp.xN) * local * local;
            }

            return L / S;
        }

        private aFunction _aFunction;
        private bFunction _bFunction;
        private InitialValueProblem _ivp;
    }
}
