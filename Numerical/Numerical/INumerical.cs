using Numerical.Core;

namespace Numerical.Numerical
{
    public interface INumerical
    {
        public Grid Solve(InitialValue initialValue);
    }
}
