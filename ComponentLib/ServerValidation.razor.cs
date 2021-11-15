using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class ServerValidation : ComponentBase
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Title { get; set; } = "Validation Errors";

        public bool Show { get; set; } = false;

        public List<ValidationResult> Errors { get; set; } = new List<ValidationResult>();

        public void ShowValidation(List<ValidationResult> errors)
        {
            Errors = errors;
            Show = true;
            StateHasChanged();
        }

        public void ShowValidation(List<string> errors)
        {
            Errors = new List<ValidationResult>();

            Errors.Add(new ValidationResult() { Field = "Title", Errors = errors });
            Show = true;
            StateHasChanged();
        }

        public void ShowValidation(Dictionary<string, string> errors)
        {
            Errors = new List<ValidationResult>();

            foreach (var error in errors)
            {
                Errors.Add(new ValidationResult() { Field = error.Key, Errors = new List<string>() { error.Value } });
            }
            Show = true;
            StateHasChanged();
        }

        public void CloseValidation()
        {
            Show = false;
            StateHasChanged();
        }

    }
}
