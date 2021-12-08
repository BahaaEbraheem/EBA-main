using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PersonTypes
{
    public class PersonTypeEditBase : EditBase<PersonType>
    {
        public Dictionary<string, string> PTypeItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> PersonItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PTypeItems = await GetIndexData<PType>();
            PersonItems = await GetIndexData<Person>();
        }
    }
}
