using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int StudioAlbums { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }

        public Band(int id, string name, int studioAlbums, string genre, string country)
        {
            Id = id;
            Name = name;
            StudioAlbums = studioAlbums;
            Genre = genre;
            Country = country;
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " " + "StudioAlbums: " + this.StudioAlbums + " Genre:" + this.Genre + " Country:" + this.Country;
        }
    }
}
