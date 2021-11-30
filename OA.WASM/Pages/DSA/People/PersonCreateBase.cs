using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.People
{
    public class PersonCreateBase : CreateBase<Person>
    {

        public Dictionary<string, string> PersonNationalityItems = new Dictionary<string, string>();
        public Dictionary<string, string> GenderItems = new Dictionary<string, string>();

       
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PersonNationalityItems = await GetIndexData<Nationality>();
            GenderItems = StaticIndexes.Gender;


        }

    }
}
