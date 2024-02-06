using Core;
using Mathematics.Statistics;
using Mathematics.Utils;
using NeuralNetwork.Optimizers;

namespace NeuralNetwork
{
    abstract public class SingleLayeredTrained : SingleLayered
    {
        public SingleLayeredTrained(int numberOfParams, Distribution.DistributionType distribution, ActivationFunction.ActivationFunctionType activationFunction):base(numberOfParams, distribution, activationFunction) {
            _weights = new Vector(_params.Points.Length);
            // this.trained = false; FIX ME
        }

        private Vector _weights;

        private Vector GradLoss(Vector input, Vector params_,
            double eps, DifferenceSchema schema)
        {
            Vector result = new Vector(params_.Points.Length);
            for(int i = 0; i < params_.Points.Length; i++)
            {
                Vector upstream;
                double lossF, lossB;

                switch (schema)
                {
                    default:
                    case DifferenceSchema.Central:
                        upstream = new Vector(params_);
                        upstream[i] += eps;
                        lossF = Loss(input, upstream, eps, schema);
                        upstream[i] -= 2 * eps;
                        lossB = Loss(input, upstream, eps, schema);
                        result[i] = (lossF - lossB) / 2 / eps;
                        break;
                    case DifferenceSchema.Feedbackward:
                        upstream = new Vector(params_);
                        lossB = Loss(input, upstream, eps, schema);
                        upstream[i] += eps;
                        lossF = Loss(input, upstream, eps, schema);
                        result[i] = (lossF - lossB) / eps;
                        break;
                    case DifferenceSchema.Feedforward:
                        upstream = new Vector(params_);
                        lossF = Loss(input, upstream, eps, schema);
                        upstream[i] -= eps;
                        lossB = Loss(input, upstream, eps, schema);
                        result[i] = (lossF - lossB) / eps;
                        break;
                }
            }

            return result;
        }
        public double TrainingStep(int epoch,
            OptimizerType optimizer,
            double learningRate, double momentum,
            Vector trainingSample,
            double eps,
            DifferenceSchema differenceSchema
            )
        {
            if (epoch == 0)
            {
                _weights = new Vector(_params.Points.Length);
            }

            Vector gradient;
            switch (optimizer)
            {
                default:
                case OptimizerType.SGD:
                    gradient = GradLoss(trainingSample, _params, eps, differenceSchema);
                    _params = _params - learningRate * gradient;
                    break;
                case OptimizerType.MomentumSGD:
                    gradient = GradLoss(trainingSample, _params, eps, differenceSchema);
                    _weights = momentum * _weights - learningRate * gradient;
                    _params = _params + _weights;
                    break;
                case OptimizerType.NesterovSGD:
                    Vector pn = _params + momentum * _weights;
                    gradient = GradLoss(trainingSample, pn, eps, differenceSchema);
                    _weights = momentum * _weights - learningRate * gradient;
                    _params = _params + _weights;
                    break;
            }
            return Loss(trainingSample, _params, eps, differenceSchema);
        }
    }
}
