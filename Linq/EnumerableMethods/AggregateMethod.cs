using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class AggregateMethod
    {
        public static int GetSumClassic(IEnumerable<int> numbersList)
        {
            int sum = 0;

            foreach (var number in numbersList)
            {
                sum = sum + number;
            }

            return sum;
        }

        public static int GetSumLinq(IEnumerable<int> numbersList)
        {
            return numbersList.Aggregate(0, (sum, next) => sum = sum + next);
        }

        //Implement the method, so it returns the sum of even numbers in the list.
        public static int GetSumOfEvenNumbers(IEnumerable<int> numbersList)
        {
            return default(int);
        }
    }
}
