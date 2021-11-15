using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Attributes;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public partial class DetailItem : ComponentBase
    {
        [Parameter]
        public string Name { get; set; } = "";

        [Parameter]
        public string Value { get; set; } = "";

        [Parameter]
        public Type EntityType { get; set; }

        [Parameter]
        public string PropName { get; set; } = "";

        [Parameter]
        public string NameSize { get; set; } = "5";

        [Parameter]
        public string ValSize { get; set; } = "7";

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }


        protected override void OnInitialized()
        {
            if (EntityType != null && PropName != "" && Name == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Name = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }

            Value = Value ?? "";

        }

    }
}
