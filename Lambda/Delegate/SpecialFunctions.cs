using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Delegate
{
    public delegate double PerformCalculation(double x, double y);

    public class SpecialFunctions
    {
        public static double Sum(double val1, double val2)
        {
            return val1 + val2;
        }

        public static double Product(double val1, double val2)
        {
            return val1 * val2;
        }

        public static double Diff(double val1, double val2)
        {
            return val1 - val2;
        }

        public static void ExecuteFunction(PerformCalculation function, double param1, double param2)
        {
            double result = function(param1, param2);
            Console.WriteLine(result);
        }
    }
}
