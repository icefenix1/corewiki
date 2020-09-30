using System;
using corewiki.Helpers;

namespace corewiki
{
    class Program
    {
        static void Main(string[] args)
        {
            var search = new Search();
            
            search.JoinAndSort(search.Request("絵文字","en"),search.Request("絵文字","jp")).ForEach(sr => {
                Console.WriteLine($"Size: {sr.size}      Title: {sr.title}      Lang:{sr.lang}");
            });            
        }
    }
}
