using Mathematics.Utils;
using static System.Math;

namespace NeuralNetwork
{
    public class ActivationFunction : IFunctionX<double>
    {
        public enum ActivationFunctionType
        {
            Identity,
            BinaryStep,
            Sigmoid,
            HyperbolicTangent,
            ReLU,
            Softplus,
            Gaussian,
        }

        public ActivationFunction(ActivationFunctionType activationType)
        {
            _activationType = activationType;
        }

        public double Apply(double x)
        {
            switch (_activationType)
            {
                default: return ReLU(x);
                case ActivationFunctionType.Identity: return Identity(x);
                case ActivationFunctionType.BinaryStep: return BinaryStep(x);
                case ActivationFunctionType.Sigmoid: return Sigmoid(x);
                case ActivationFunctionType.HyperbolicTangent: return HyperbolicTangent(x);
                case ActivationFunctionType.ReLU: return ReLU(x);
                case ActivationFunctionType.Softplus: return Softplus(x);
                case ActivationFunctionType.Gaussian: return Gaussian(x);
            }
        }

        private double Identity(double x)
        {
            return x;
        }

        private double BinaryStep(double x)
        {
            return x < 0.0 ? 0.0 : 1.0;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Exp(-x));
        }

        private double HyperbolicTangent(double x)
        {
            return (Exp(x) - Exp(-x))/(Exp(x) + Exp(-x));
        }

        private double ReLU(double x)
        {
            return Max(0, x);
        }

        private double Softplus(double x)
        {
            return Log(Exp(1), 1 + Exp(x));
        }

        private double Gaussian(double x)
        {
            return Exp(-(x * x));
        }

        private ActivationFunctionType _activationType;
    }
}
