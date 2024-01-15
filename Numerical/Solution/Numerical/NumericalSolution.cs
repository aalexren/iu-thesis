using Core;
using Numerical.Numerical;

namespace Numerical.Solution.Numerical
{
    public class NumericalSolution
    {
        public NumericalSolution(InitialValueProblem initialValueProblem, double startPoint, double finishPoint, int numberOfPoints)
        {
            _initialValueProblem = initialValueProblem;
            _startPoint = startPoint;
            _finishPoint = finishPoint;
            _numberOfPoints = numberOfPoints;
            _Init();
        }

        public NumericalSolution(InitialValueProblem initialValueProblem, double startPoint, double finishPoint, double step)
        {
            _initialValueProblem = initialValueProblem;
            _startPoint = startPoint;
            _finishPoint = finishPoint;
            _step = step;
            _Init();
        }

        private void _Init()
        {
            _step = _step ?? (_finishPoint - _startPoint) / (_numberOfPoints - 1);
            _grid = _GetSizedGrid();
        }

        public Grid Solve(INumericalMethod<double> numericalMethod)
        {
            int axisLength = _grid.X.Points.Length;
            Grid g = new Grid(_grid);
            g.Y[0] = _initialValueProblem.Value;
            for (int i = 1; i < axisLength; i++)
            {
                g.Y[i] = numericalMethod.GetNextY(_initialValueProblem.Derivative, g.X[i - 1], g.Y[i - 1], (double)_step);
            }
            return g;
        }

        private Vector _GetSizedVector()
        {
            int length = (int)(_numberOfPoints ?? (_finishPoint - _startPoint) / _step);
            //double[] axis = (double[])Array.CreateInstance(typeof(double), length);
            return new(new double[length]);
        }

        private Grid _GetSizedGrid()
        {
            Vector xAxis = _FillVector(_GetSizedVector());
            Vector yAxis = _GetSizedVector();
            Grid grid = new(xAxis, yAxis);
            return grid;
        }

        private Vector _FillVector(Vector sized)
        {
            Vector res = Vector.DeepCopy(sized);
            res[0] = _startPoint;
            for (int i = 1; i < res.Points.Length; i++)
            {
                res[i] = (double)(res[i - 1] + _step);
            }
            return res;
        }

        public double StartPoint => _startPoint;
        public double FinishPoint => _finishPoint;

        private InitialValueProblem _initialValueProblem;
        private Grid _grid;
        private double _startPoint;
        private double _finishPoint;
        private double? _step;
        private int? _numberOfPoints;
    }
}
