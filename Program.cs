using System;
using Magpie.Library;
using Magpie.Library.Attributes;

namespace ConsoleApplication
{
    public class Program
    {
        public class SozlukModel
        {
            [AttributeBinding(Selector = "#topic h1", AttributeName = "data-title")]
            public string Title { get; set; }
            [InnerTextBinding(Selector = "#entry-list div.content")]
            public string Description { get; set; }
        }

        public static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            var result = crawler.Crawl<SozlukModel>("https://eksisozluk.com/entry/50961685");
            result.ContinueWith( (t, o)=>{
                if(t.IsFaulted) {
                    Console.WriteLine($"{t.Exception.Message}");
                }
            }, null);
            result.Wait();

            Console.WriteLine($"Title: '{result.Result.Title}'. \r\nDescription: '{result.Result.Description}'");
        }
    }
}