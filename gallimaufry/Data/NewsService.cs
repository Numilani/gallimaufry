using System;
using System.Threading.Tasks;
using Flurl.Http;
using gallimaufry.Pages.news;

namespace gallimaufry.Data
{
    public class NewsService
    {
        private DateTime lastChecked = DateTime.MinValue;

        private NewsApiResponse news;

        public async Task<NewsApiResponse> GetNews()
        {
            if ((DateTime.Now - lastChecked).TotalHours > 1)
            {
                Console.WriteLine("More than 1 hour, fetching new headlines...");
                news = await RequestNews();
                lastChecked = DateTime.Now;
                return news;
            }
            else
            {
                Console.WriteLine("<1 hr, old news...");
                return news;
            }
        }
        
        private async Task<NewsApiResponse> RequestNews()
        {
            string url = $"https://newsapi.org/v2/top-headlines?language=en&apikey=2920a81f9ab644c893c8d1a3bc722de0&sources=the-wall-street-journal,the-hill,politico,newsweek,msnbc,fortune,business-insider,associated-press,abc-news,reuters&from={DateTime.Today.AddDays(-1):yyyy-MM-dd}&to={DateTime.Today:yyyy-MM-dd}&pagesize=100";
            var x = url.GetJsonAsync<NewsApiResponse>();
            return await x;
        }
    }
}