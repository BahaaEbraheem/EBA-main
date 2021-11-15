using Microsoft.AspNetCore.Components;
using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.Settings;
using OA.WASM.Services;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Attachments
{
    public partial class AttachmentForm : ComponentBase
    {
        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Attachment Attachment { get; set; } = new Attachment();

        [Inject]
        public IServiceProvider ServiceProvider { get; set; }

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        public List<string> AllowedTypes { get; set; } = new List<string>();

        public Dictionary<string, Dictionary<string, string>> References { get; set; } = new Dictionary<string, Dictionary<string, string>>();

        public bool Initilzed { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Active = (IsEdit) ? "active" : "";

            AllowedTypes = FileSettings.MimeTypes["HTML"];

            StaticIndexes.AttachemntReferences.ToList().ForEach(i => References.Add(i.Key, new Dictionary<string, string>()));

            if (IsEdit && !string.IsNullOrEmpty(Attachment.Reference))
                await ReferenceSelected(Attachment.Reference);            
            
            Initilzed = true;
        }

        public async Task ReferenceSelected(string reference)
        {
            if(References.Keys.Contains(reference) && References[reference].Count == 0)
            {
                var data = new Dictionary<string, string>();

                data = reference switch
                {
                    nameof(Page) => await GetIndexData<Page>(),
                    nameof(Block) => await GetIndexData<Block>(),
                    nameof(Menue) => await GetIndexData<Menue>(),
                    nameof(Event) => await GetIndexData<Event>(),
                    nameof(Article) => await GetIndexData<Article>(),
                    _ => new Dictionary<string, string>()
                };

                References[reference] = data;
            }
        }


        public async Task<Dictionary<string, string>> GetIndexData<U>() where U : class
        {
            var service = (ServiceBase<U>)ServiceProvider.GetService(typeof(ServiceBase<U>));
            var list = await service.IndexGet();

            var dic = new Dictionary<string, string>();
            list.ForEach(i => dic.Add($"{i.Id}", $"{i.Name}"));

            return dic;
        }

    }
}
