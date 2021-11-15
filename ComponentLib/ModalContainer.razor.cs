using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class ModalContainer : ComponentBase
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Show { get; set; } = "";

        [Parameter]
        public string Size { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback CloseEvent { get; set; }

        public async Task OnClose()
        {
            if (CloseEvent.HasDelegate)
                await CloseEvent.InvokeAsync(null);
        }

    }
}
