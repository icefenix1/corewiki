namespace corewiki.Models
{
    public class SearchResponse
    {
        public string lang { get; set; }
        public string title { get; set; }
        public int size { get; set; }

        public SearchResponse(Search search, string searchLang)
        {
            lang = searchLang;
            title = search.title;
            size = search.size;
        }
    }
}