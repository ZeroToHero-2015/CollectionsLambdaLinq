using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class SelectMethod
    {
        public static IEnumerable<BandSummary> GetBandSummariesClassic(IEnumerable<Band> fullBandInfo)
        {
            foreach (var bandInfo in fullBandInfo)
            {
                yield return new BandSummary(bandInfo.Name, bandInfo.Genre);
            }
        }

        public static IEnumerable<BandSummary> GetBandSummariesLinqSql(IEnumerable<Band> fullBandInfo)
        {
            return from bandInfo in fullBandInfo
                   select new BandSummary(bandInfo.Name, bandInfo.Genre);
        }

        public static IEnumerable<BandSummary> GetBandSummariesLinqLambda(IEnumerable<Band> fullBandInfo)
        {
            return fullBandInfo.Select(bandInfo => new BandSummary(bandInfo.Name, bandInfo.Genre));
        }

        //Implement the method, so it returns a list of strings, with the following format:
        //"bandName comes from bandCountry, plays bandGenre, and has released bandStudioAlbums albums so far"
        public static IEnumerable<string> GetBandsReadableDescriptions(IEnumerable<Band> fullBandInfo)
        {
            return null;
        }
    }
}
