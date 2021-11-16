﻿using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.ArticleTranslations
{
    public class ArticleTranslationCreateBase : CreateBase<ArticleTranslation>
    {
        public Dictionary<string, string> ArticleItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ArticleItems = await GetIndexData<Article>();
            LanguageItems = await GetIndexData<Language>();
        }

    }
}
