using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Articles
{
    public class ArticlesListBase : ListBase<Article>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(ArticleCategory))
            {
                indexData = await GetIndexData<ArticleCategory>();
            }

            GridFilterRef.IndexDatas = indexData;
        }

    }
}
