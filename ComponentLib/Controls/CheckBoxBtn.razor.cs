using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib.Controls
{
    public partial class CheckBoxBtn : ComponentBase
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public bool Checked { get; set; } = false;

        [Parameter]
        public string Text { get; set; } = "Check";

        [Parameter]
        public string ClassList { get; set; } = "";

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attrs { get; set; }

        [Parameter]
        public EventCallback<bool> OnChange { get; set; }

        public async Task Changed()
        {
            Checked = !Checked;
            StateHasChanged();
            await OnChange.InvokeAsync(Checked);
        }

    }
}
