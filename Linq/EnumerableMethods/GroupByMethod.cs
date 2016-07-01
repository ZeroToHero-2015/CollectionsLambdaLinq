using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<IGrouping<string, Band>> GetBandsGroupedByCountryLinqSql(List<Band> bandsList)
        {
            return from band in bandsList
                   group band by band.Country;
        }

        public static IEnumerable<IGrouping<string, Band>> GetBandsGroupedByCountryLinqLambda(IEnumerable<Band> bands)
        {
            return bands.GroupBy(band => band.Country);
        }

        // Group the bands by the number of albums using a for/foreach syntax
        public static IDictionary<int, List<Band>> GetBandsGroupedByNumberOfAlbumsClassic(IEnumerable<Band> bands)
        {
            return null;
        }

        // Group the bands by the number of albums using Lambda syntax
        public static IEnumerable<IGrouping<int, Band>> GetBandsGroupedByNumberOfAlbumsLinqLambda(IEnumerable<Band> bands)
        {
            return null;
        }

        // Group the bands by the number of albums using SQL syntax
        public static IEnumerable<IGrouping<int, Band>>  GetBandsGroupedByNumberOfAlbumsLinqSql(IEnumerable<Band> bands)
        {
            return null;
        }
    }
}
