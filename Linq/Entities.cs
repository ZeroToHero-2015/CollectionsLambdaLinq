using System.Collections.Generic;

namespace Linq
{
    public class Band
    {
        public string Name { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }
        public IEnumerable<string> Albums { get; private set; }

        public Band(string name, string genre, string country, IEnumerable<string> albums)
        {
            Name = name;
            Genre = genre;
            Country = country;
            Albums = albums;
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
