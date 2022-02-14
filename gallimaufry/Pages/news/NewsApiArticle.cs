using System;
using System.Collections.Generic;

namespace gallimaufry.Pages.news
{
    public class NewsApiArticle
    {
        public NewsApiArticleSource source;
        public string author;
        public string title;
        public string description;
        public string url;
        public string urlToImage;
        public DateTime publishedAt;
        public string content;
    }

    public class NewsApiArticleSource
    {
        public string id;
        public string name;
    }
}