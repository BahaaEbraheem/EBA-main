using OA.DataAccess;
using OA.Domin.Administration;
using OA.Domin.AutoMapper;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
//using OA.Domin.DSA.ViewModels;
using OA.Domin.Responces;
using OA.Services.Administration;
using OA.Services.DSA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.DSA
{
    public class AdministrationBoardService : IAdministrationBoardService
    {
        private readonly AppDbContext Context;
        private readonly IAdministrationService AdministrationService;
        public AdministrationBoardService(AppDbContext context, IAdministrationService administrationService)
        {
            Context = context;
            AdministrationService = administrationService;
        }


        public async Task<Response<string>> AdministrationBoardCreate(AdministrationBoardVM administrationboardvm)
        {
            //Add Beneficiary with assosiated user
            var administrationboard = Mapping.Mapper.Map<AdministrationBoard>(administrationboardvm);
            var response = new Response<string>();
            var r = Context.SaveChanges();
            response.HasErrors = (r == 0);

            return response;
        }



    }
}
