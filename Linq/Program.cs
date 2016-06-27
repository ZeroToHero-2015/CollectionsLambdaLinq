using Linq.EnumerableMethods;
using System;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {
        private static readonly List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
        private static readonly List<Band> bandsList = new List<Band>
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
            //WhereExample();
            SelectExample();
            //SelectManyExample();
            //AggregateExample();
            //GroupByExample();
            //SumMaxMinExample();
        }

        private static void WhereExample()
        {
            Console.WriteLine("=====Example 1 (Where example)=====");

            Console.WriteLine();
            var evenNumbersClassic = WhereMethod.GetEvenNumbersClassic(numbersList);
            WriteNumbersList(evenNumbersClassic);

            Console.WriteLine();
            var evenNumbersSql = WhereMethod.GetEvenNumbersLinqSql(numbersList);
            WriteNumbersList(evenNumbersSql);

            Console.WriteLine();
            var evenNumbersLambda = WhereMethod.GetEvenNumbersLinqLambda(numbersList);
            WriteNumbersList(evenNumbersLambda);

            //TODO 1: Implement WhereMethod.GetBandsThatStartWithBlack

            Console.WriteLine();
        }

        private static void SelectExample()
        {
            Console.WriteLine("=====Example 2 (Select example)=====");

            Console.WriteLine();
            var bandSummariesClassic = SelectMethod.GetBandSummariesClassic(bandsList);
            WriteBandSummaries(bandSummariesClassic);

            Console.WriteLine();
            var bandSummariesLinqSql = SelectMethod.GetBandSummariesLinqSql(bandsList);
            WriteBandSummaries(bandSummariesLinqSql);

            Console.WriteLine();
            var bandSummariesLinqLambda = SelectMethod.GetBandSummariesLinqLambda(bandsList);
            WriteBandSummaries(bandSummariesLinqLambda);

            //TODO 2: Implement SelectMethod.GetBandsReadableDescriptions

            Console.WriteLine();
        }

        #region Helper Methods

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

        private static void WriteBandSummaries(IEnumerable<BandSummary> bandList)
        {
            foreach (var band in bandList)
            {
                Console.WriteLine($"{band.Name}, {band.Genre}");
            }
        }

        #endregion
    }
}
