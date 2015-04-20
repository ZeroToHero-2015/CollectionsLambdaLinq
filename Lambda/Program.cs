using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambda.Delegate;
using System.Collections;

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


            /**
             * TODO 0
             * Goto SpecialFunctions sources and resolve TODO 1, 2 and 3.
             */

            //TODO 4: Create an instance of NumberCheck

            //TODO 5: Use function GetEvenNumbers to select the even numbers from numbersList collection
            ArrayList numbersList = new ArrayList(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });

            //TODO 6: Print the resulted numbers


            Console.WriteLine();
        }

        public static void FuncDelegateExample()
        {
            Console.WriteLine("=====Example 2 (Func Delegate)===");

            //Create Func Delegate instances
            Func<double, double, double> sum_Function = new Func<double, double, double>(SpecialFunctions.Sum);
            Func<double, double, double> prod_Function = new Func<double, double, double>(SpecialFunctions.Product);

            double val1 = 4.0, val2 = 5.0;

            //Call sum function
            double sum_result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

            //Call product function
            double prod_result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(prod_Function, val1, val2);

            //Omitting the explicit creation of Func instance
            Console.Write("{0} - {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(SpecialFunctions.Diff, val1, val2);

            ArrayList numbersList = new ArrayList(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            /**
             * TODO 7 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */

            Console.WriteLine();
        }

        static void AnonymousFunctExample()
        {
            Console.WriteLine("=====Example 3 (Anonymous Functions)===");

            //Create a Func Delegate instance
            Func<double, double, double> sum_Function = delegate(double var1, double var2)
            {
                return var1 + var2;
            };
            //Create a Delegate instance
            PerformCalculation prod_Function = delegate(double var1, double var2)
            {
                return var1 * var2;
            };


            double val1 = 4.0, val2 = 3.0;

            //Call sum function
            double sum_result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_result);

            //Call product function
            double prod_result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            /**
             * TODO 8 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //run Delegate example
            DelegateExample();

            //run Func Delegate example
            FuncDelegateExample();

            //run Anonymous functions example
            AnonymousFunctExample();

            Console.ReadKey();
        }
    }
}
