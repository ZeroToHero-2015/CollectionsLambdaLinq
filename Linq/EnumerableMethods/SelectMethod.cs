using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class SelectMethod
    {
        public static IEnumerable<BandSummary> GetBandSummariesClassic(IEnumerable<Band> fullBandsInfo)
        {
            foreach (var bandInfo in fullBandsInfo)
            {
                yield return new BandSummary(bandInfo.Name, bandInfo.Genre);
            }
        }

        public static IEnumerable<BandSummary> GetBandSummariesLinqSql(IEnumerable<Band> fullBandsInfo)
        {
            return from bandInfo in fullBandsInfo
                   select new BandSummary(bandInfo.Name, bandInfo.Genre);
        }

        public static IEnumerable<BandSummary> GetBandSummariesLinqLambda(IEnumerable<Band> fullBandsInfo)
        {
            return fullBandsInfo.Select(bandInfo => new BandSummary(bandInfo.Name, bandInfo.Genre));
        }

        //Implement the method, so it returns a list of strings, with the following format:
        //"bandName comes from bandCountry, plays bandGenre, and has released bandStudioAlbums albums so far"
        public static IEnumerable<string> GetBandsReadableDescriptions(IEnumerable<Band> fullBandsInfo)
        {
            return null;
        }
    }
}
