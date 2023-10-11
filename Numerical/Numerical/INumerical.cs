using Numerical.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical.Numerical
{
    public interface INumerical
    {
        public Grid Solve(InitialValue initialValue);
    }
}
