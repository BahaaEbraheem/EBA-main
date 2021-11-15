using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class Confirm : ComponentBase
    {
        public bool Show { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Title { get; set; } = "Delete Confirm";

        [Parameter]
        public string Text { get; set; } = "Are you sure ?";

        [Parameter]
        public string CancelTxt { get; set; } = "Cancel";

        [Parameter]
        public string ConfirmTxt { get; set; } = "Confirm";

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void ModalShow()
        {
            Show = true;
            StateHasChanged();
        }

        public async Task OnConfirmation(bool value)
        {
            Show = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
