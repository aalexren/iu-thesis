using Core;
using Mathematics.ODE;
using Numerical.Solution.Analytical;
using Numerical.Solution.Numerical;
using System.Linq;

namespace Numerical.Solution.Error
{
    internal class GlobalError
    {
        public static double ComputeGlobalError(LocalError localError)
        {
            return localError.Grid.Y.Points.Max();
        }


        public static Grid ComputeGlobalError(ExactSolution exactSolution, INumericalMethod<double> numericalMethod, InitialValueProblem ivp)
        {
            int left = 10, right = 50;

            Grid result = new(new(right - left), new(right - left));
            for (int i = left; i < right; i++)
            {
                NumericalSolution solution = new(ivp, i);
                Grid curNumSol = solution.Solve(numericalMethod);
                ExactSolution curExact = new(curNumSol.X, exactSolution.function);
                LocalError localError = LocalError.ComputeLocalError(curExact.Solve(), curNumSol);
                result.Y[i - left] = ComputeGlobalError(localError);
                result.X[i - left] = i;
            }
            return result;
        }


    }
}
