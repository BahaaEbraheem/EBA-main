using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.WASM.Shared;
using OA.Domin;
using static OA.Domin.StaticIndexes;

namespace OA.WASM.Pages.DSA.People
{
    public partial class PersonForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Person Person { get; set; } = new Person();

        [Parameter]
        public Dictionary<string, string> PersonNationalityItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> GenderItems { get; set; } = new Dictionary<string, string>();

        //private Gender genderItems;

        //public Gender GetGenderItems()
        //{

        //    return genderItems;
        //}

        //public void SetGenderItems(Gender value)
        //{
        //    genderItems = value;
        //}



        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
            GenderItems = StaticIndexes.Gender;



        }

    }
}
