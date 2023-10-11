using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            ScottPlot.Plot myPlot = new(400, 300);
            myPlot.AddScatter(dataX, dataY);

            new ScottPlot.FormsPlotViewer(myPlot).ShowDialog();
        }
    }
}