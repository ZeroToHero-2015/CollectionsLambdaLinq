using System.Collections.Generic;

namespace Collections.List
{
    public class BasicBandsComparer : IComparer<Band>
    {
        public int Compare(Band firstBand, Band secondBand)
        {
            if (firstBand.StudioAlbums > secondBand.StudioAlbums)
            {
                return -1;
            }

            if (firstBand.StudioAlbums < secondBand.StudioAlbums)
            {
                return 1;
            }

            return 0;
        }
    }
}
