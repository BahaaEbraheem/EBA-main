using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.WASM.Shared;
using OA.Domin;
using static OA.Domin.StaticIndexes;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;

namespace OA.WASM.Pages.DSA.AdministrationBoards
{
   
    public partial class AdministrationBoardForm : ComponentBase
    {


        [Parameter]
        public bool IsEdit { get; set; }
        [Parameter]
        public Dictionary<string, string> PtypeItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> PersonNationalityItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public AdministrationBoard AdministrationBoard { get; set; } = new AdministrationBoard();

        [Parameter]
        public Person Person { get; set; } = new Person();

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
        }
        //public void DonatorTypeSelected(string selected)
        //{
        //   // PersonType.Description = selected;
         
        //    StateHasChanged();
        //}
    }
}
