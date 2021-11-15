using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using OA.Domin.Attributes;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComponentLib.Controls
{
    public class MNInputDecimalBase : InputBase<decimal?>
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public Expression<Func<decimal?>> For { get; set; }

        [Parameter]
        public Type EntityType { get; set; } = null;

        [Parameter]
        public string PropName { get; set; } = "";

        protected override void OnInitialized()
        {
            if (EntityType != null && PropName != "" && Label == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Label = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }
        }

        protected override bool TryParseValueFromString(string value, out decimal? result, out string validationErrorMessage)
        {
            int.TryParse(value, out var intValue);

            result = intValue;
            validationErrorMessage = null;
            return true;
        }

    }
}
