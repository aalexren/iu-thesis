using System;
using System.Linq;
using Core.Machine;
using Mathematics.Utils;

namespace Core
{
    public class Vector
    {
        public Vector(int size)
        {
            _points = new double[size];
        }
        public Vector(double[] points)
        {
            _points = points;
        }

        public Vector(int size, double start, double stop, double? step = null)
        {
            _points = new double[size];
            step = step ?? (start - stop) / (size - 1);
            _points = Enumerable.Range(1, size - 1).Select(i => _points[i] = (double)(_points[i - 1] + step)).ToArray();
        }

        public Vector(Vector vector)
        {
            _points = DeepCopy(vector)._points;
        }

        public double[] Points => _points;

        public override string ToString()
        {
            return "[" + _points.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next) + "]";
        }

        public Vector SubVector(int from, int to) => new(_points.Skip(from).Take(to - from).ToArray());

        public double Magnitude() => Math.Sqrt(_points.Zip(_points, (x, y) => x * y).Sum());

        public Vector Vectorize(FunctionX<double> functionToApply) => new(_points.Select(x => functionToApply(x)).ToArray());

        public Vector Vectorize(IFunctionX<double> functionToApply) => new(_points.Select(functionToApply.Apply).ToArray());

        public static Vector operator +(Vector a, Vector b) => new(a._points.Zip(b._points, (x, y) => x + y).ToArray());

        public static Vector operator -(Vector a, Vector b) => new(a._points.Zip(b._points, (x, y) => x - y).ToArray());

        public static Vector operator *(Vector a, double b) => new(a._points.Select(x => x * b).ToArray());

        public static Vector operator *(double b, Vector a) => new(a._points.Select(x => x * b).ToArray());

        public static double operator *(Vector a, Vector b) => a._points.Zip(b._points, (x, y) => x * y).Sum();

        public static bool operator ==(Vector a, Vector b) => a._points.Zip(b._points, (x, y) => _Equals(x, y, Epsilon.EPSILON)).ToArray().All(x => x);

        public static bool operator !=(Vector a, Vector b) => !(a == b);

        public static Vector DeepCopy(Vector vector) => new(vector._points.Select(x => x).ToArray());

        private static bool _Equals(double x, double y, double tolerance)
        {
            var diff = Math.Abs(x - y);
            return diff <= tolerance ||
                   diff <= Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
        }

        public double this[int i]
        {
            get { return _points[i]; }
            set { _points[i] = value; }
        }

        private double[] _points;
    }
}
