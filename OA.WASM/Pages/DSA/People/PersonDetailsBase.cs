using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.People
{
    public class PersonDetailsBase : DetailsBase<Person>
    {

        [Inject]
        public IConfiguration Configuration { get; set; }

        public string PathPrefix { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PathPrefix = Configuration.GetSection("BaseUri").Value;

        }

    }
}
