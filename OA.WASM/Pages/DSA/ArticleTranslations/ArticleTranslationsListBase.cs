using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.ArticleTranslations
{
    public partial class ArticleTranslationsListBase : ListBase<ArticleTranslation>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(Article))
            {
                indexData = await GetIndexData<Article>();
            }

            GridFilterRef.IndexDatas = indexData;
        }

    }
}
