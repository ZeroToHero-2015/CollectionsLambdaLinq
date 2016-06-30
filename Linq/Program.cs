using Linq.EnumerableMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        private static readonly List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
        private static readonly List<Band> bandsList = new List<Band>
        {
            new Band("Led Zeppelin", "Hard Rock", "England", 
                new List<string> { "LZ Album 1", "LZ Album 2", "LZ Album 3" }),
            new Band("Judas Priest", "Heavy Metal", "England",
                new List<string> { "JP Album 1", "JP Album 2" }),
            new Band("Phoenix", "Rock", "Romania",
                new List<string> { "Phx Album 1", "Phx Album 2", "Phx Album 3", "Phx Album 4" }),
            new Band("Black Sabbath", "Heavy Metal", "England",
                new List<string> { "BS Album 1", "BS Album 2" }),
            new Band("Rammstein", "Industrial Metal", "Germany",
                new List<string> { "Rms Album 1", "Rms Album 2" }),
            new Band("Black Keys", "Indie Rock", "United States",
                new List<string> { "BK Album 1", "BK Album 2", "BK Album 3", "BK Album 4" }),
            new Band("Muse", "Alternative Rock", "England",
                new List<string> { "Mus Album 1", "Mus Album 2", "Mus Album 3" })
        };

        static void Main(string[] args)
        {
            //WhereExample();
            //SelectExample();
            //SelectManyExample();
            //AggregateExample();
            GroupByExample();
            //SumMaxMinExample();

            Console.ReadKey();
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

        private static void SelectManyExample()
        {
            Console.WriteLine("=====Example 3 (SelectMany example)=====");

            Console.WriteLine();
            var albumsClassic = SelectManyMethod.GetAllAlbumsClassic(bandsList);
            WriteStrings(albumsClassic);

            Console.WriteLine();
            var albumsLinqSql = SelectManyMethod.GetAllAlbumsLinqSql(bandsList);
            WriteStrings(albumsLinqSql);

            Console.WriteLine();
            var albumsLinqLambda = SelectManyMethod.GetAllAlbumsLinqLambda(bandsList);
            WriteStrings(albumsLinqLambda);

            //TODO 3: Implement SelectManyMethod.GetAllWordsInAllAlbums

            Console.WriteLine();
        }

        private static void AggregateExample()
        {
            Console.WriteLine("=====Example 4 (Aggregate example)=====");

            Console.WriteLine();
            var sumClassic = AggregateMethod.GetSumClassic(numbersList);
            Console.Write(sumClassic);

            Console.WriteLine();
            var sumLinq = AggregateMethod.GetSumLinq(numbersList);
            Console.Write(sumLinq);

            //TODO 4: Implement AggregateMethod.GetSumOfEvenNumbers

            Console.WriteLine();
        }

        private static void GroupByExample()
        {
            Console.WriteLine("=====Example 5 (GroupBy example)=====");

            Console.WriteLine();
            var bandsGroupedByCountryClassic = GroupByMethod.GetBandsGroupedByCountryClassic(bandsList);
            WriteBandNamesGroupedByKey(bandsGroupedByCountryClassic);

            Console.WriteLine();
            var bandsGroupedByCountryLinq = GroupByMethod.GetBandsGroupedByCountryLinq(bandsList);
            WriteBandNamesGroupedByKey(bandsGroupedByCountryLinq.ToDictionary(b => b.Key, b => b.ToList()));

            Console.WriteLine();
            var bandsGroupedByCountrySql = GroupByMethod.GetBandsGroupedByCountrySql(bandsList);
            WriteBandNamesGroupedByKey(bandsGroupedByCountrySql.ToDictionary(b => b.Key, b => b.ToList()));

            
            Console.WriteLine();
            var bandsGroupedByNumberOfAlbumsClassic = GroupByMethod.GetBandsGroupedByNumberOfAlbumsClassic(bandsList); //TODO 5: Implement GroupByMethod.GetBandsGroupedByNumberOfAlbums using a for/foreach syntax
            WriteBandNamesGroupedByKey(bandsGroupedByNumberOfAlbumsClassic);

            Console.WriteLine();
            var bandsGroupedByNumberOfAlbumsLinq = GroupByMethod.GetBandsGroupedByNumberOfAlbumsLinq(bandsList); //TODO 6: Implement GroupByMethod.GetBandsGroupedByNumberOfAlbums using LINQ syntax
            WriteBandNamesGroupedByKey(bandsGroupedByNumberOfAlbumsLinq?.ToDictionary(b => b.Key.ToString(), b => b.ToList()));

            Console.WriteLine();
            var bandsGroupedByNumberOfAlbumsSql = GroupByMethod.GetBandsGroupedByNumberOfAlbumsSql(bandsList); //TODO 7: Implement GroupByMethod.GetBandsGroupedByNumberOfAlbums using SQL syntax
            WriteBandNamesGroupedByKey(bandsGroupedByNumberOfAlbumsSql?.ToDictionary(b => b.Key.ToString(), b => b.ToList()));
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

        private static void WriteStrings(IEnumerable<string> stringsToWrite)
        {
            foreach (var stringToWrite in stringsToWrite)
            {
                Console.Write($"{stringToWrite}, ");
            }
        }

        private static void WriteBandNamesGroupedByKey(IDictionary<string, List<Band>> bandsGroupedByCountry)
        {
            if (bandsGroupedByCountry == null)
                return;
            
            foreach (var bandsByCountryGroup in bandsGroupedByCountry)
            {
                var key = bandsByCountryGroup.Key;
                var bands = bandsByCountryGroup.Value;

                Console.Write($"Bands with key = {key}: ");

                foreach (var band in bands)
                {
                    Console.Write($"{band.Name}, ");
                }

                Console.WriteLine();
            }
        }

        #endregion
    }
}
