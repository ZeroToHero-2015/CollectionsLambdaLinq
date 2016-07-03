using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class SumMaxMinMethod
    {
        public static int SumNumberOfTotalAlbumsClassic(IEnumerable<Band> bands)
        {
            var numberOfAlbums = 0;

            foreach (var band in bands)
            {
                numberOfAlbums = numberOfAlbums + band.Albums.Count();
            }

            return numberOfAlbums;
        }

        public static int SumNumberOfTotalAlbumsLinq(IEnumerable<Band> bands)
        {
            return bands.Sum(b => b.Albums.Count());
        }

        public static int MinNumberOfAlbumsClassic(IEnumerable<Band> bands)
        {
            var minNumberOfAlbums = int.MaxValue;

            foreach (var band in bands)
            {
                var numberOfAlbums = band.Albums.Count();

                if (numberOfAlbums < minNumberOfAlbums)
                    minNumberOfAlbums = numberOfAlbums;
            }

            return minNumberOfAlbums;
        }

        public static int MinNumberOfAlbumsLinq(List<Band> bandsList)
        {
            return bandsList.Min(band => band.Albums.Count());
        }

        // Return the total number of albums released by English bands
        public static int GetNumberOfAlbumsByEnglishBands(List<Band> bandsList)
        {
            return default(int);
        }
    }
}