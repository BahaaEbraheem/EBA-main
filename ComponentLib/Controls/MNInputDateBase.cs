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
    public class MNInputDateBase : InputBase<DateTime?>
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public Expression<Func<DateTime?>> For { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public bool Init { get; set; }

        public string Format { get; set; }

        [Parameter]
        public Type EntityType { get; set; } = null;

        [Parameter]
        public string PropName { get; set; } = "";


        protected override void OnInitialized()
        {
            base.OnInitialized();

            Format = (Type == "date") ? "yyyy-MM-dd" : "yyyy-MM-ddTHH:mm";

            if (Init) CurrentValue = DateTime.Now;

            if (EntityType != null && PropName != "" && Label == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Label = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }

        }

        protected override bool TryParseValueFromString(string value, out DateTime? result, out string validationErrorMessage)
        {
            result = CurrentValue;
            validationErrorMessage = "";
            return true;
        }
    }
}
