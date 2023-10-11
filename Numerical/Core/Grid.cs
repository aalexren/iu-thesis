namespace Numerical.Core
{
    public class Grid
    {
        public Grid(Vector x, Vector y)
        {
            _x = x;
            _y = y;
        }

        public Vector X => _x;
        public Vector Y => _y;

        private Vector _x;
        private Vector _y;
    }
}
