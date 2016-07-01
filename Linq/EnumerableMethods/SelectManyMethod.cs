using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class SelectManyMethod
    {
        public static IEnumerable<string> GetAllAlbumsClassic(IEnumerable<Band> fullBandsInfo)
        {
            var allAlbums = new List<string>();

            foreach (var bandInfo in fullBandsInfo)
            {
                foreach (var album in bandInfo.Albums)
                {
                    allAlbums.Add(album);
                }
            }

            return allAlbums;
        }

        public static IEnumerable<string> GetAllAlbumsLinqSql(IEnumerable<Band> fullBandsInfo)
        {
            return from bandInfo in fullBandsInfo
                   from album in bandInfo.Albums
                   select album;
        }

        public static IEnumerable<string> GetAllAlbumsLinqLambda(IEnumerable<Band> fullBandsInfo)
        {
            return fullBandsInfo.SelectMany(bandInfo => bandInfo.Albums);
        }

        //Implement the method, so it returns a list of strings, each representing a word in the name of a band album.
        //EX: {"LZ Album 1", LZ Album 2"} => {"LZ", "Album", "1", "LZ", "Album", "2"}
        //Hint: Use string.Split(' ') to get a list of words from a string.
        public static IEnumerable<string> GetAllWordsInAllAlbums(IEnumerable<Band> fullBandsInfo)
        {
            return new List<string>();
        }
    }
}
