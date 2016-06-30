using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Linq.EnumerableMethods
{
    public class GroupByMethod
    {

        public static IDictionary<string, List<Band>> GetBandsGroupedByCountryClassic(IEnumerable<Band> bands)
        {
            var bandsGroupedByCountry = new Dictionary<string, List<Band>>();

            foreach (var band in bands)
            {
                if (bandsGroupedByCountry.ContainsKey(band.Country))
                {
                    bandsGroupedByCountry[band.Country].Add(band);
                }
                else
                {
                    bandsGroupedByCountry.Add(band.Country, new List<Band> {band});
                }
            }

            return bandsGroupedByCountry;
        }

        public static IEnumerable<IGrouping<string, Band>> GetBandsGroupedByCountryLinq(IEnumerable<Band> bands)
        {
            return bands.GroupBy(band => band.Country);
        }

        public static IEnumerable<IGrouping<string, Band>> GetBandsGroupedByCountrySql(List<Band> bandsList)
        {
            return from band in bandsList
                   group band by band.Country;
        }

        public static IDictionary<string, List<Band>> GetBandsGroupedByNumberOfAlbumsClassic(IEnumerable<Band> bands)
        {
            //TODO 5 group the bands by the number of albums using a for/foreach syntax
            //For the sake of simplicity convert the number of the albums to a string
            return null;
        }

        public static IEnumerable<IGrouping<int, Band>> GetBandsGroupedByNumberOfAlbumsLinq(IEnumerable<Band> bands)
        {
            //TODO 6 group the bands by the number of albums using LINQ syntax
            return null;
        }

        public static IEnumerable<IGrouping<int, Band>>  GetBandsGroupedByNumberOfAlbumsSql(IEnumerable<Band> bands)
        {
            //TODO 7 group the bands by the number of albums using SQL syntax
            return null;
        }
    }
}
