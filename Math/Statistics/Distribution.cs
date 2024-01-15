using Mathematics.Utils;
using static System.Math;

namespace Mathematics.Statistics
{
    public class Distribution : IFunctionX<double>
    {

        public enum DistributionType
        {
            Uniform,
            Gaussian,
        }
        public Distribution(DistributionType dt) 
        {
            _distributionType = dt;
        }

        public double Apply(double x)
        {
            switch (_distributionType)
            {
                default: return Gaussian(x);
                case DistributionType.Uniform: return Uniform(x);
                case DistributionType.Gaussian: return Gaussian(x);
            }
        }

        private double Gaussian(double x, double mu = 0.0, double sigma = 1.0)
        {
            return 1.0 / (sigma * Sqrt(2.0 * PI) * Exp(-0.5 * Pow((x - mu) / sigma, 2)));
        }

        private double Uniform(double x, double constant = 1.0)
        {
            return constant;
        }

        private DistributionType _distributionType;
    }
}
