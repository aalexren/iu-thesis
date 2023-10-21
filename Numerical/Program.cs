using Numerical.Core;
using Numerical.Numerical;
using Numerical.Solution.Analytical;
using Numerical.Solution.Numerical;
using ScottPlot;
using System;

namespace Numerical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector x = new(new double[] { 1.0, 2.5, 3.0 });
            Vector y = Vector.DeepCopy(x);
            Console.WriteLine(x == y);
            Console.WriteLine(ReferenceEquals(x, y));
            Console.WriteLine(ReferenceEquals(x.Points, y.Points));
            Console.WriteLine(x != y);
            Console.WriteLine(x * y);
            Console.WriteLine(x + y);
            Console.WriteLine(x - y);
            Console.WriteLine(x * 5.0);
            Console.WriteLine(5.0 * y);
            Console.WriteLine(x.Magnitude());
            Console.WriteLine(x.SubVector(1, 3));

            InitialValueProblem ivp = new(3.0, (x, y) => -2 * y + 3 * Math.Pow(Math.E, x));
            NumericalSolution solution = new(ivp, 0.0, 10.0, 100);
            //solution.Init();
            EulerMethod eulerMethod = new();
            Grid eulerSolution = solution.Solve(eulerMethod);
            Console.WriteLine(eulerSolution.ToString());

            Grid exactSolution = ExactSolution.Solve(eulerSolution.X, (x) => 2 * Math.Pow(Math.E, -2 * x) + Math.Pow(Math.E, x));

            Plot solutionPlot = new();
            solutionPlot.AddScatter(eulerSolution.X.Points, eulerSolution.Y.Points);
            solutionPlot.AddScatter(exactSolution.X.Points, exactSolution.Y.Points);
            new FormsPlotViewer(solutionPlot).ShowDialog();

            Console.ReadKey();
        }
    }
}