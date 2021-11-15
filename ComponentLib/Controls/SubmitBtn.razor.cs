using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib.Controls
{
    public partial class SubmitBtn : ComponentBase
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public bool Busy { get; set; }

        [Parameter]
        public string Text { get; set; } = "Save";

    }
}
