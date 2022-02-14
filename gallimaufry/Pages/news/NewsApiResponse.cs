using System.Collections.Generic;

namespace gallimaufry.Pages.news
{
    public class NewsApiResponse
    {
        public string status;
        public int totalResults;
        public List<NewsApiArticle> articles;
    }
}