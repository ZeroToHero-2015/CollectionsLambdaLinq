using Lambda.Delegate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        public static void DelegateExample()
        {
            Console.WriteLine("=====Example 1 (Delegate)===");

            //Create Delegate instances
            PerformCalculation sum_Function = new PerformCalculation(SpecialFunctions.Sum);
            PerformCalculation prod_Function = new PerformCalculation(SpecialFunctions.Product);

            double val1 = 2.0, val2 = 3.0;

            //Call sum function
            double sum_result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

            //Call product function
            double prod_result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //run Delegate example
            DelegateExample();

            Console.ReadKey();
        }
    }
}
