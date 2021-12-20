using Microsoft.AspNetCore.Identity;
using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.DSA.ViewModels;
using OA.Domin.DSA;
using OA.Domin.Logging;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.COM_ADM

{
    public interface ICOM_ADMService
    {
       IEnumerable<AdministrationBoardVM> ADDCOM(AdministrationBoardVM Commission_admini_VM);
        //IEnumerable<AdministrationBoard> GetAllAdministrators();
 
    }
}
