using Microsoft.AspNetCore.Components;
using OA.Domin;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.ArticleCategories
{
    public partial class ArticleCategoryForm : ComponentBase
    {
        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public ArticleCategory ArticleCategory { get; set; } = new ArticleCategory();

        public Dictionary<string, string> ArticleCategoryTypeItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

            ArticleCategoryTypeItems = StaticIndexes.ArticleCategoryTypes;
        }
    }
}
