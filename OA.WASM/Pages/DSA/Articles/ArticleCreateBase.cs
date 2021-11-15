using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Articles
{
    public class ArticleCreateBase : CreateBase<Article>
    {
        public Dictionary<string, string> ArticleCatigoryItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ArticleCatigoryItems = await GetIndexData<ArticleCategory>();

        }
    }
}
