using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using gallimaufry.Data;
using Microsoft.AspNetCore.Components;

namespace gallimaufry.Pages.news
{
    public partial class Newsfeed : ComponentBase
    {
        [Inject]
        public NewsService News { get; set; }
        
        private NewsApiResponse articleList;

        protected override async Task OnInitializedAsync()
        {
            articleList = await News.GetNews();
        }

    }
}