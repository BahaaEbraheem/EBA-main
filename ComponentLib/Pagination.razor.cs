using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.ComponentFeatures;
using OA.Domin.Paging;
using OA.Domin.RequestFeatures;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class Pagination : ComponentBase
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public PagingMetaData PagingData { get; set; }

        [Parameter]
        public int Spread { get; set; }

        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        [CascadingParameter]
        public Theme Theme { get; set; }

        private List<PagingLink> Links;

        protected override void OnParametersSet()
        {
            CreatePagingLinks();
        }

        private void CreatePagingLinks()
        {
            Links = new List<PagingLink>(){
                new PagingLink(1, "<<", PagingData.HasPrevios),
                new PagingLink(PagingData.CurrentPage - 1, Localizer["Prev"], PagingData.HasPrevios)
            };

            for(int i = 1; i<PagingData.TotalPages; i++)
            {
                if(i > (PagingData.CurrentPage - Spread) && i < (PagingData.CurrentPage + Spread))
                {
                    Links.Add(new PagingLink(i, i.ToString(), true) { Active = (PagingData.CurrentPage == i) });
                }
            }

            Links.Add(new PagingLink(PagingData.CurrentPage + 1, Localizer["Next"], PagingData.HasNext));
            Links.Add(new PagingLink(PagingData.TotalPages - 1, ">>", PagingData.HasNext));

        }

        public async Task OnPageSelected(PagingLink link)
        {
            if (!link.Enabled || link.Page == PagingData.CurrentPage)
                return;

            PagingData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);

        }

    }
}
