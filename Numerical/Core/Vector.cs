using System.Linq;

namespace Numerical
{
    public class Vector
    {
        public Vector(double[] _points)
        {
            this._points = _points;
        }
        public double[] Points => _points;

        public override string ToString() {
            return "Vector: " + _points.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next);
        }

        public static Vector operator +(Vector a, Vector b) => new(a._points.Zip(b._points, (x, y) => x + y).ToArray());
        public static Vector operator -(Vector a, Vector b) => new(a._points.Zip(b._points, (x, y) => x - y).ToArray());
        public static Vector operator *(Vector a, double b) => new(a._points.Select(x => x * b).ToArray());
        public static Vector operator *(double b, Vector a) => new(a._points.Select(x => x * b).ToArray());
        public static double operator *(Vector a, Vector b) => a._points.Zip(b._points, (x, y) => x * y).Sum();
        public static bool operator ==(Vector a, Vector b) => a._points.Zip(b._points, (x, y) => x == y).ToArray().All(x => x);
        public static bool operator !=(Vector a, Vector b) => !(a == b);
        public static Vector Copy(Vector x) => new(x._points);

        private double[] _points;
    }
}
