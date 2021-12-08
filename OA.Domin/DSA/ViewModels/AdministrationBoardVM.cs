using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.ViewModels
{

    public class AdministrationBoardVM
    {
        private readonly ILazyLoader Loader;
        public AdministrationBoardVM(ILazyLoader loader)
        {
            Loader = loader;
        }

        public AdministrationBoardVM()
        {
          
        }


       public AdministrationBoard AdministrationBoard { get; set; }
        public PersonType PersonType { get; set; }
        public Person Person { get; set; }
        
        public string PTypeName { get; set; }

    }
}
