namespace Linq
{
    public class Band
    {
        public string Name { get; private set; }
        public int StudioAlbums { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }

        public Band(string name, int studioAlbums, string genre, string country)
        {
            Name = name;
            StudioAlbums = studioAlbums;
            Genre = genre;
            Country = country;
        }
    }

    public class BandSummary
    {
        public string Name { get; private set; }
        public string Genre { get; private set; }

        public BandSummary(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
