using System.Collections.Generic;

namespace corewiki.Models
{
    public class Continue
    {
        public int sroffset { get; set; }
        public string @continue { get; set; }
    }

    public class Searchinfo
    {
        public int totalhits { get; set; }
    }

    public class Search
    {
        public int ns { get; set; }
        public string title { get; set; }
        public int pageid { get; set; }
        public int size { get; set; }
    }

    public class Query
    {
        public Searchinfo searchinfo { get; set; }
        public List<Search> search { get; set; }
    }

    public class WikiResponse
    {
        public string batchcomplete { get; set; }
        public Continue @continue { get; set; }
        public Query query { get; set; }
    }
}