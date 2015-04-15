using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Collections.Collection;
using Collections.Enumerable;
using Collections.List;

namespace Collections
{
    class Program
    {
        private static readonly Band[] BandsArray =
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
            //YieldExample();
            //EnumerableExample();
            //CollectionExample();
            //ListExample();
            DictionaryExample();
        }

        private static void DictionaryExample()
        {
            
        }

        private static void YieldExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Yield Example-----------------------------");

            foreach (var frontman in FrontmenList())
            {
                Console.WriteLine(frontman);
            }

            Console.WriteLine();

            var bandsList = new List<Band>(BandsArray);
            foreach (var bandName in BandNames(bandsList))
            {
                Console.WriteLine(bandName);
            }
        }

        private static IEnumerable BandNames(IEnumerable<Band> bandsList)
        {
            int index = 0;
            foreach (var band in bandsList)
            {
                yield return index + " " + band.Name;
                index++;
            }
        }

        private static IEnumerable<string> FrontmenList()
        {
            yield return "Robert Plant";
            yield return "Rob Halford";
            yield return "Nicu Covaci";
            yield return "Ozzy Osbourne";
            yield return "Till Lindemann";
            yield return "Dan Auerbach";
            yield return "Matt Bellamy";
        }

        private static void ListExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------List Example-----------------------------");

            var bandsList = new List<Band>(BandsArray);

            bandsList.Sort(new BasicBandsComparer());
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.Country));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.Name));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.AlbumCount));

            var index = 0;
            foreach (var band in bandsList)
            {
                Console.WriteLine("{0} {1} {2} {3}", index, band.Name, band.StudioAlbums, band.Country);
                index ++;
            }

            Console.WriteLine();

            var bandsToAdd = new[]
            {
                new Band("Guta", 0, "", ""),
                new Band("Salam", 0, "", "")
            };
            bandsList.AddRange(bandsToAdd);
            var lastTwoBands = bandsList.GetRange(bandsList.Count - 2, 2);

            foreach (var bandName in BandNames(lastTwoBands))
            {
                Console.WriteLine(bandName);
            }

            Console.WriteLine();

            var indexNewGuta = bandsList.IndexOf(new Band("Guta", 0, "", ""));
            Console.WriteLine("Index of new Guta is {0}", indexNewGuta);
            var indexRefGuta = bandsList.IndexOf(bandsToAdd[0]);
            Console.WriteLine("Index of reference Guta is {0}", indexRefGuta);
        }

        private static void CollectionExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Collection Example-----------------------------");

            var bandsCollection = new BandsCollection(BandsArray);

            bandsCollection.Insert(0, new Band("Guta", 0, "", ""));
            bandsCollection.Insert(3, new Band("Salam", 0, "", ""));
            bandsCollection.Insert(8, new Band("Susanu", 0, "", ""));

            bandsCollection[3] = new Band("Romeo Fantastik", 0, "", "");

            bandsCollection.RemoveAt(8);

            Console.WriteLine();

            foreach (var bandName in BandNames(bandsCollection))
            {
                Console.WriteLine(bandName);
            }
        }

        private static void EnumerableExample()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Enumerable Example-----------------------------");

            var bands = new BandsEnumerable(BandsArray);

            var enumerator = bands.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var band = enumerator.Current;
                Console.WriteLine("{0} ({1}, {2}): {3} albums.", band.Name, band.Genre, band.Country, band.StudioAlbums);
            }
        }
    }
}
