using Linq.EnumerableMethods;
using System;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {
        private static readonly List<int> NumbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
        private static readonly List<Band> BandsList = new List<Band>
        {
            new Band("Led Zeppelin", 9, "Hard Rock", "England"),
            new Band("Judas Priest", 17, "Heavy Metal", "England"),
            new Band("Phoenix", 10, "Rock", "Romania"),
            new Band("Black Sabbath", 19, "Heavy Metal", "England"),
            new Band("Rammstein", 6, "Industrial Metal", "Germany"),
            new Band("Black Keys", 8, "Indie Rock", "United States"),
            new Band("Muse", 6, "Alternative Rock", "England")
        };

        static void Main(string[] args)
        {
            WhereExample();
            //SelectExample();
            //SelectManyExample();
            //AggregateExample();
            //GroupByExample();
            //SumMaxMinExample();
        }

        private static void WhereExample()
        {
            Console.WriteLine("=====Example 1 (Where example)=====");

            Console.WriteLine();
            var evenNumbersClassic = WhereMethod.GetEvenNumbersClassic(NumbersList);
            WriteNumbersList(evenNumbersClassic);

            Console.WriteLine();
            var evenNumbersLambda = WhereMethod.GetEvenNumbersLinqLambda(NumbersList);
            WriteNumbersList(evenNumbersLambda);

            Console.WriteLine();
            var evenNumbersSql = WhereMethod.GetEvenNumbersLinqSql(NumbersList);
            WriteNumbersList(evenNumbersSql);

            //TODO 1: Implement WhereMethod.GetBandsThatStartWithBlack

            Console.WriteLine();
        }

        private static void WriteNumbersList(IEnumerable<int> numbersList)
        {
            foreach (var number in numbersList)
            {
                Console.Write($"{number} ");
            }
        }

        private static void WriteBandNames(IEnumerable<Band> bandList)
        {
            foreach (var band in bandList)
            {
                Console.Write($"{band.Name}, ");
            }
        }
    }
}
