using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    class Program
    {
        private static List<Band> GetBands()
        {
            return new List<Band>
            {
                new Band(1, "Led Zeppelin", 9, "Hard Rock", "England"),
                new Band(2, "Judas Priest", 17, "Heavy Metal", "England"),
                new Band(3, "Phoenix", 10, "Rock", "Romania"),
                new Band(4, "Black Sabbath", 19, "Heavy Metal", "England"),
                new Band(5, "Rammstein", 6, "Industrial Metal", "Germany"),
                new Band(6, "Black Keys", 8, "Indie Rock", "United States"),
                new Band(7, "Muse", 6, "Alternative Rock", "England")
            };
        }

        private static List<Song> GetSongs()
        {
            return new List<Song>
            {
                new Song(1, "Song1", 1),
                new Song(2, "Song2", 1),
                new Song(3, "Song3", 2),
                new Song(4, "Song4", 3),
                new Song(5, "Song5", 4),
                new Song(6, "Song6", 4),
                new Song(7, "Song7", 5),
                new Song(8, "Song8", 6)
            };
        }

        private static readonly IEnumerable<Band> Bands = GetBands();

        private static readonly IEnumerable<Song> Songs = GetSongs();

        static void Main(string[] args)
        {
            //ShowList(Bands);

            var bandMinAlbums = Bands.Min(b => b.StudioAlbums);
            Console.WriteLine(bandMinAlbums.ToString());

            var bandMaxAlbums = Bands.Max(b => b.StudioAlbums);
            Console.WriteLine(bandMaxAlbums.ToString());

            //var filteredBands = StartsWith("L");
            //ShowList(filteredBands);
            //---
            //var filteredBands = StartsWithLinq1("L");
            //ShowList(filteredBands);

            //OrderByNrOfStudioAlbums();
            //Console.WriteLine();
            //OrderByNrOfStudioAlbumsLinq();

            //GroupByCountryLync1();
            //Console.WriteLine();
            //GroupByCountryLync2();

            //GetSongsForBandsLinq1();
            //Console.WriteLine();
            //GetSongsForBandsLinq2();

            //GetSongsForAllBandsLinq1();
            //Console.WriteLine();
            //GetSongsForAllBandsLinq2();

            //GetSongsForAllBandsGroupJoin1();
            //Console.WriteLine();
            //GetSongsForAllBandsGroupJoin2();

            Console.ReadLine();
        }

        #region StartsWith

        public static IEnumerable<Band> StartsWith(string filterName)
        {
            var filteredResults = new List<Band>();

            foreach (var band in Bands)
            {
                if (band.Name.StartsWith(filterName))
                {
                    filteredResults.Add(band);
                }
            }

            return filteredResults;
        }

        public static IEnumerable<Band> StartsWithLinq1(string filterName)
        {
            var filteredBands = from band in Bands
                                where band.Name.StartsWith(filterName)
                                select band;

            return filteredBands;
        }

        public static IEnumerable<Band> StartsWithLinq2(string filterName)
        {
            var filterBands = Bands.Where(b => b.Name.StartsWith(filterName));

            return filterBands;
        }

        #endregion

        #region StudioAlbumsGreaterThan - TODO

        public static void StudioAlbumsGreaterThan(int noOfAlbums)
        {
            var myBands = GetBands();

            //...Your code here....

            ShowList(myBands);
        }

        #endregion

        #region OrderByNrOfStudioAlbums

        public static void OrderByNrOfStudioAlbums()
        {
            var myBands = GetBands();

            Band aux;
            for (var index1 = 0; index1 < myBands.Count(); index1++)
            {
                for (var index2 = 0; index2 < myBands.Count(); index2++)
                {
                    if (myBands[index1].StudioAlbums < myBands[index2].StudioAlbums)
                    {
                        aux = myBands[index1];
                        myBands[index1] = myBands[index2];
                        myBands[index2] = aux;
                    }
                }
            }

            ShowList(myBands);
        }

        public static void OrderByNrOfStudioAlbumsLinq()
        {
            var myBands = GetBands();

            var orderedBands = myBands.OrderBy(b => b.StudioAlbums);

            ShowList(orderedBands);
        }

        #endregion

        #region GroupByCountry

        public static void GroupByCountryLync1()
        {
            var groupedBands = 
                        from band in Bands
                         group band by band.Country into bC
                         select new
                         {
                             Country = bC.Key,
                             NumberOfBands = bC.Count()
                         };

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Country: " + group.Country + " NumberOfBands: " + group.NumberOfBands);
            }
        }

        public static void GroupByCountryLync2()
        {
            var groupedBands = Bands.GroupBy(b => b.Country).Select(g => new { Country = g.Key, NumberOfBands = g.Count()});

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Country: " + group.Country + " NumberOfBands: " + group.NumberOfBands);
            }
        }

        #endregion

        #region GroupByGenre - TODO

        public static void GroupByGenreLync1()
        { 
            //.....Your code here......
        }

        public static void GroupByGenreLync2()
        {
            //.....Your code here......
        }
        
        #endregion

        #region GetSongsForAllBands()

        //INNER JOIN
        public static void GetSongsForBandsLinq1()
        {
            var bandSongs = from band in Bands
                       join song in Songs on band.Id equals song.BandId
                       select new { 
                            Band = band.Name,
                            Song = song.Name
                       };

            foreach (var bandSong in bandSongs)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //INNER JOIN
        public static void GetSongsForBandsLinq2()
        {
            var bandSongs = Bands.Join(Songs, b => b.Id, s => s.BandId, (band, song) => new
            {
                Band = band.Name,
                Song = song.Name
            });

            foreach (var bandSong in bandSongs)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //LEFT JOIN
        public static void GetSongsForAllBandsLinq1()
        {
            var bandSongsResult = from band in Bands
                            join song in Songs on band.Id equals song.BandId into bandSongs
                            from item in bandSongs.DefaultIfEmpty(new Song(0, "-", 0))
                            select new
                            {
                                Band = band.Name,
                                Song = item.Name
                            };

            foreach (var bandSong in bandSongsResult)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //LEFT JOIN
        public static void GetSongsForAllBandsLinq2()
        { 
            var bandSongsResult =
                Bands.GroupJoin(
                Songs,
                b => b.Id,
                s => s.BandId,
                (band, song) => new
                {
                    Band = band.Name,
                    Song = song.DefaultIfEmpty(new Song(0, "-", 0))
                })
                .SelectMany(a => a.Song.Select(s => new { Band = a.Band, Song = s.Name}));
            
            foreach (var bandSong in bandSongsResult)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }

        }

        //GROUP JOIN
        public static void GetSongsForAllBandsGroupJoin1()
        {
            var bandSongsResult = from band in Bands
                                  join song in Songs on band.Id equals song.BandId into bandSongs
                                  select new { BandName = band.Name, Songs = bandSongs };

            foreach(var band in bandSongsResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var song in band.Songs)
                {
                    Console.WriteLine("---" + song.Name);
                }
            }
        }

        //GROUP JOIN
        public static void GetSongsForAllBandsGroupJoin2()
        {
            var bandSongsResult = Bands.GroupJoin(Songs, b => b.Id, s => s.BandId, (band, songs) => new { BandName = band.Name, Songs = songs});

            foreach (var band in bandSongsResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var song in band.Songs)
                {
                    Console.WriteLine("---" + song.Name);
                }
            }
        }

        #endregion

        public static void ShowList(IEnumerable<Band> bands)
        {
            foreach (var band in bands)
                Console.WriteLine(band.ToString());
        }

        //HOME TODO - de creat entitatea Membru (Id, BandId, Name)
        //De implementat toate metodele de la join, group join Ex: (GetMembersForBandsLinq1)
    }
}
