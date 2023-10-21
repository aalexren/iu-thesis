using Numerical.Utils;

namespace Numerical.Solution.Numerical
{
    public interface INumericalMethod<T>
    {
        /// <summary>
        /// Gets the next point y[i + 1] of the approximate solution
        /// depending on the previous point (x[i],y[i]) and the step h of the grid
        /// </summary>
        /// <param name="equation">Equation to bo solved</param>
        /// <param name="x">x-coordinate previous point (x[i], y[i]) of approximate solution</param>
        /// <param name="y">y-coordinate previous point (x[i], y[i]) of approximate solution</param>
        /// <param name="step">grid step</param>
        /// <returns>value of the approximate solution at the next point y[i+1]</returns>
        public T GetNextY(FunctionXY<T> equation, T x, T y, T step);
    }
}
