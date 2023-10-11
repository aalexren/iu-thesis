using System;

namespace Numerical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double[] dataX = { 1, 2, 3, 4, 5 };
            //double[] dataY = { 1, 4, 9, 16, 25 };

            //ScottPlot.Plot myPlot = new(400, 300);
            //myPlot.AddScatter(dataX, dataY);

            //new ScottPlot.FormsPlotViewer(myPlot).ShowDialog();
            Vector x = new(new double[] { 1.0, 2.0, 3.0 });
            Vector y = Vector.Copy(x);
            Console.WriteLine(x == y);
            Console.WriteLine(object.ReferenceEquals(x, y));
            Console.WriteLine(x != y);
            Console.WriteLine(x * y);
            Console.WriteLine(x + y);
            Console.WriteLine(x - y);

            Console.ReadKey();
        }
    }
}