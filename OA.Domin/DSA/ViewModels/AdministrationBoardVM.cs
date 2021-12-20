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
    [NotMapped]
    public class AdministrationBoardVM
    {
  
       public List<AdministrationBoard> AdministrationBoardList { get; set; }
        public CommissionMember CommissionMember { get; set; }
        public Commission Commission { get; set; }
        public int CommissionId { get; set; }

        public PersonType PersonType { get; set; }
        public Person Person { get; set; }
        
        public string PTypeName { get; set; }

    }
}
