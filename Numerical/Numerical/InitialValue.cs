using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical.Numerical
{
    public class InitialValue
    {
        public InitialValue(double value, Func<double> derivative)
        {
            _value = value;
            _derivative = derivative;
        }

        public double Value => _value;
        public Func<double> Derivative => _derivative;

        private double _value;
        private Func<double> _derivative;
    }
}
