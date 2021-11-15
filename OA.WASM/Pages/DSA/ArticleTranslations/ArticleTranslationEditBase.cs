using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.ArticleTranslations
{
    public class ArticleTranslationEditBase : EditBase<ArticleTranslation>
    {

        public Dictionary<string, string> ArticleItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ArticleItems = await GetIndexData<Article>();

            EntityItem.Article = null;

        }

    }
}
