using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using corewiki.Models;
using Newtonsoft.Json;

namespace corewiki.Helpers
{
    public class Search
    {
        private readonly HttpClient _client;

        public Search()
        {
            _client = new HttpClient();
        }


        // Makes a wikipedia search in a specific language 
        public List<SearchResponse> Request(string search, string lang)
        {
            var url = $"https://{lang}.wikipedia.org/w/api.php?action=query&format=json&srlimit=100&prop=&list=search&meta=&srsearch={System.Web.HttpUtility.UrlEncode(search)}&srnamespace=0&sroffset=100&srprop=size&srsort=relevance";

            HttpResponseMessage response = _client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var resp = response.Content.ReadAsStringAsync().Result;

            WikiResponse wr = JsonConvert.DeserializeObject<WikiResponse>(resp);

            return wr.query.search.Select(s => new SearchResponse(s, lang)).ToList();
        }

        // Joins 2 SearchResponse lists and returns the first 20 based on page size.
        public List<SearchResponse> JoinAndSort(List<SearchResponse> response1, List<SearchResponse> response2)
        {
            var toRetrun = new List<SearchResponse>();
            toRetrun.AddRange(response1);
            toRetrun.AddRange(response2);

            return toRetrun.OrderByDescending(s => s.size).Take(20).ToList();
        }
    }
}