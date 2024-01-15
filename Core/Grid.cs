namespace Core
{
    public class Grid
    {
        public Grid(Vector x, Vector y)
        {
            _x = x;
            _y = y;
        }

        public Grid(Grid grid)
        {
            _x = Vector.DeepCopy(grid.X);
            _y = Vector.DeepCopy(grid.Y);
        }

        public override string ToString()
        {
            return X.ToString() + "\n" + Y.ToString();
        }

        public Vector X => _x;
        public Vector Y => _y;

        private Vector _x;
        private Vector _y;
    }
}
