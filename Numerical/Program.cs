using Core;
using Numerical.Numerical;
using Numerical.Solution.Analytical;
using Numerical.Solution.Error;
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
            NumericalSolution solution = new(ivp, 0.0, 10.0, 50);
            Grid eulerSolution = solution.Solve(new EulerMethod());
            Grid improvedSolution = solution.Solve(new ImprovedEulerMethod());
            Grid rungekuttaSolution = solution.Solve(new RungeKuttaMethod());
            Console.WriteLine(eulerSolution.ToString());

            ExactSolution exactSolution = new(eulerSolution.X, (x) => 2 * Math.Pow(Math.E, -2 * x) + Math.Pow(Math.E, x));
            Grid exactSolutionGrid = ExactSolution.Solve(exactSolution.X, exactSolution.function);

            Plot solutionPlot = new();
            solutionPlot.AddScatter(eulerSolution.X.Points, eulerSolution.Y.Points, System.Drawing.Color.Blue);
            solutionPlot.AddScatter(improvedSolution.X.Points, improvedSolution.Y.Points, System.Drawing.Color.Red);
            solutionPlot.AddScatter(rungekuttaSolution.X.Points, rungekuttaSolution.Y.Points, System.Drawing.Color.Green);
            solutionPlot.AddScatter(exactSolutionGrid.X.Points, exactSolutionGrid.Y.Points, System.Drawing.Color.Yellow);
            new FormsPlotViewer(solutionPlot).ShowDialog();

            LocalError localErrorEuler = LocalError.ComputeLocalError(exactSolutionGrid, eulerSolution);
            LocalError localErrorIEuler = LocalError.ComputeLocalError(exactSolutionGrid, improvedSolution);
            LocalError localErrorRK = LocalError.ComputeLocalError(exactSolutionGrid, rungekuttaSolution);

            Plot localErrorPlot = new();
            localErrorPlot.AddScatter(localErrorEuler.Grid.X.Points, localErrorEuler.Grid.Y.Points, System.Drawing.Color.Blue);
            localErrorPlot.AddScatter(localErrorIEuler.Grid.X.Points, localErrorIEuler.Grid.Y.Points, System.Drawing.Color.Green);
            localErrorPlot.AddScatter(localErrorRK.Grid.X.Points, localErrorRK.Grid.Y.Points, System.Drawing.Color.Firebrick);

            new FormsPlotViewer(localErrorPlot).ShowDialog();

            Grid globalErrorEuler = GlobalError.ComputeGlobalError(exactSolution, solution, new EulerMethod(), ivp);
            Grid globalErrorIEuler = GlobalError.ComputeGlobalError(exactSolution, solution, new ImprovedEulerMethod(), ivp);
            Grid globalErrorRK = GlobalError.ComputeGlobalError(exactSolution, solution, new RungeKuttaMethod(), ivp);

            Plot globalErrorPlot = new();
            globalErrorPlot.AddScatter(globalErrorEuler.X.Points, globalErrorEuler.Y.Points, System.Drawing.Color.Blue);
            globalErrorPlot.AddScatter(globalErrorIEuler.X.Points, globalErrorIEuler.Y.Points, System.Drawing.Color.Green);
            globalErrorPlot.AddScatter(globalErrorRK.X.Points, globalErrorRK.Y.Points, System.Drawing.Color.Firebrick);

            new FormsPlotViewer(globalErrorPlot).ShowDialog();

            //Console.ReadKey();
        }
    }
}