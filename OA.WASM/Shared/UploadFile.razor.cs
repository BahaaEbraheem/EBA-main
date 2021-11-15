using ComponentLib;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.RequestFeatures;
using OA.Domin.Resources;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public partial class UploadFile : ComponentBase
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public bool Multible { get; set; } = false;

        [Parameter]
        public long MaxSize { get; set; } = 0;

        [Parameter]
        public List<string> Types { get; set; } = new List<string>();

        [Parameter]
        public bool ImagePreview { get; set; } = false;

        [Parameter]
        public bool ShowUploaded { get; set; } = false;

        [Parameter]
        public EventCallback OnValidUpload { get; set; }

        [Parameter]
        public EventCallback OnStartPreUpload { get; set; }

        [Parameter]
        public EventCallback OnEndPreUpload { get; set; }

        [Parameter]
        public string CssClass { get; set; } = "upload-control";

        public List<string> UploadedNames { get; set; } = new List<string>();

        public string Base64Img { get; set; }

        public List<ValidationResult> Errors { get; set; } = new List<ValidationResult>();

        public bool HasErrors { get { return Errors.Count > 0; } }

        public List<RequestFileData> Files { get; set; } = new List<RequestFileData>();


        public ServerValidation Validation { get; set; } = new ServerValidation();

        public bool UploadBusy { get; set; }

        public async Task Upload(IMatFileUploadEntry[] files)
        {
            UploadBusy = true;

            Files = new List<RequestFileData>();

            if (OnStartPreUpload.HasDelegate)
                await OnStartPreUpload.InvokeAsync(null);

            Errors = new List<ValidationResult>();
            if (ValidateFiles(files))
            {
                Validation.ShowValidation(Errors);

                if (OnEndPreUpload.HasDelegate)
                    await OnEndPreUpload.InvokeAsync(null);

                return;
            }

            foreach (var file in files)
            {
                var name = file.Name;
                var type = file.Type;
                var size = file.Size;

                var ms = new MemoryStream();
                await file.WriteToStreamAsync(ms);
                var bytes = ms.ToArray();

                Files.Add(new RequestFileData()
                {
                    Data = bytes,
                    FileType = type,
                    Size = size,
                    Name = name,
                });

                if (file.Type.Contains("image"))
                {
                    Base64Img = $"data:{file.Type};base64,";                    
                    Base64Img += Convert.ToBase64String(bytes);
                }

                UploadedNames.Add(name);
            }

            if (OnEndPreUpload.HasDelegate)
                await OnEndPreUpload.InvokeAsync(null);

            if(OnValidUpload.HasDelegate)
                await OnValidUpload.InvokeAsync(null);

            UploadBusy = false;
        }

        public bool ValidateFiles(IMatFileUploadEntry[] files)
        {
            foreach (var file in files)
            {
                var name = file.Name;
                var type = file.Type;
                var size = file.Size;

                var errors = new List<string>();

                if (Types.Count() > 0 && !Types.Contains(type))
                    errors.Add(Localizer["File type not allowed"]);
                if (MaxSize != 0 && size > MaxSize)
                {
                    var mbLimit = MaxSize / (1024 * 1024); //in MB
                    var mbSize = size / (1024 * 1024);
                    errors.Add($"Size({mbSize} MB) {Localizer["File size exceeded the allowed limit"]} ({mbLimit} MB)");
                }

                if (errors.Count > 0)
                    Errors.Add(new ValidationResult() { Field = name, Errors = errors });
            }

            return Errors.Count() > 0;
        }

    }
}
