using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class CollapseContainer : ComponentBase
    {

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; } = "";

        [Parameter]
        public string Title { get; set; } = "Collapse";

        [Parameter]
        public bool Show { get; set; } = false;

        [Parameter]
        public bool HasFooter { get; set; } = true;

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public EventCallback<bool> OnToggle { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Id = $"{Id}_{Guid.NewGuid()}";
        }

        public async Task Toggle()
        {
            Show = !Show;
            if (OnToggle.HasDelegate)
                await OnToggle.InvokeAsync(Show);
        }

    }
}
